using AutoMapper;
using StoreWeb.Core;
using StoreWeb.Core.Extensions;
using StoreWeb.Core.Log;
using StoreWeb.Data;
using StoreWeb.Entity;
using StoreWeb.Services.Abstract;
using StoreWeb.Services.Enum;
using StoreWeb.Services.Pvo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace StoreWeb.Services.ServiceImpl
{
    public partial class UserServiceImpl:IDependency,IUserService
    {
        public IMenuService menuService { get; set; }
        public IRoleService roleService { get; set; }
        public IUserRoleService userRoleService { get; set; }
        public IRoleMenuService roleMenuService { get; set; }
        public ILoginLogService loginLogService { get; set; }
        public Result<UserPvo> Login(UserPvo pvo)
        {
            var res = new Result<UserPvo>();
            try
            {
                var user = GetOne(item => item.LoginName == pvo.LoginName);
                if (user == null)
                    res.msg = "无效的用户";
                else
                {
                    loginLogService.Add(new LoginLogPvo
                    {
                        UserId = user.Id,
                        LoginName = user.LoginName,
                        IP = WebHelper.GetClientIP(),
                        Mac=WebHelper.GetClientMacAddress()
                    });
                    if (user.Password != pvo.Password.ToMD5())
                        res.msg = "登录密码错误";
                    else if (user.IsDelete)
                        res.msg = "用户已被删除";
                    else if (user.Status == UserStatus.未激活)
                        res.msg = "账号未激活";
                    else if (user.Status == UserStatus.禁用)
                        res.msg = "账号被禁用";
                    else
                    {
                        res.flag = true;
                        res.msg = "登录成功";
                        res.data = user;
                        DateTime expiration = pvo.IsRememberMe ? DateTime.Now.AddDays(7) : DateTime.Now.Add(FormsAuthentication.Timeout);
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2, user.LoginName, DateTime.Now, expiration, true, user.Id.ToString(), FormsAuthentication.FormsCookiePath);
                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket))
                        {
                            HttpOnly = true,
                            Expires = expiration
                        };
                        HttpContext.Current.Response.Cookies.Add(cookie);
                    }
                }
            }catch(Exception ex)
            {
                res.msg = ex.Message;
                Logger.Log(ex.Message, ex);
            }
            return res;
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
            var cookie = HttpContext.Current.Response.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
        public List<MenuPvo> GetMyMenus(int userId)
        {
            var userRoles = userRoleService.Query(item => !item.IsDelete && item.UserId == userId, item => item.Id, false);
            var roleIds = userRoles.Select(item => item.RoleId).Distinct();
            var roleMenus = roleMenuService.Query(item => !item.IsDelete && roleIds.Contains(item.RoleId), item => item.Id, false);
            var menuIds = roleMenus.Select(item => item.MenuId).Distinct();
            return menuService.Query(item => !item.IsDelete && menuIds.Contains(item.Id), item => item.Order, false);
        }
        public ResultPvo<RolePvo> GetMyRole(QueryBase query, int userId)
        {
            using(var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = scope.DbContexts.Get<StoreContext>();
                var userRoleDbSet = db.Set<UserRoleEntity>().AsNoTracking().OrderBy(item => item.CreateTime).Where(item => item.UserId == userId).ToList();
                var roleIds = userRoleDbSet.Select(item => item.RoleId).Distinct().ToList();
                Expression<Func<RolePvo, bool>> exp = item => (!item.IsDelete && roleIds.Contains(item.Id));
                if (!query.SearchKey.IsBlank())
                    exp = exp.And(item => item.Name.Contains(query.SearchKey));
                var where = exp.Cast<RolePvo, RoleEntity, bool>();
                var roleDbSet = db.Set<RoleEntity>().AsNoTracking().OrderBy(item => item.CreateTime).Where(where);
                var list = roleDbSet.Skip(query.Start).Take(query.Length).ToList();
                var pvo = new ResultPvo<RolePvo>
                {
                    recordsTotal = roleDbSet.Count(),
                    data = Mapper.Map<List<RoleEntity>, List<RolePvo>>(list)
                };
                return pvo;
            }
        }

        public ResultPvo<RolePvo> GetNotMyRoles(QueryBase query, int userId)
        {
            using(var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = scope.DbContexts.Get<StoreContext>();
                var userRoleDbSet = db.Set<UserRoleEntity>().AsNoTracking().OrderBy(item => item.CreateTime).Where(item => item.UserId == userId).ToList();
                var roleIds = userRoleDbSet.Select(item => item.RoleId).Distinct().ToList();
                Expression<Func<RolePvo, bool>> exp = item => (!item.IsDelete && !roleIds.Contains(item.Id));
                if (!query.SearchKey.IsBlank())
                    exp = exp.And(item => item.Name.Contains(query.SearchKey));
                var where = exp.Cast<RolePvo, RoleEntity, bool>();
                var roleDbSet = db.Set<RoleEntity>().AsNoTracking().OrderBy(item => item.CreateTime).Where(where);
                var list = roleDbSet.Skip(query.Start).Take(query.Length).ToList();
                var pvo = new ResultPvo<RolePvo>
                {
                    recordsTotal = roleDbSet.Count(),
                    data = Mapper.Map<List<RoleEntity>, List<RolePvo>>(list)
                };
                return pvo;
            }
        }
    }
}
