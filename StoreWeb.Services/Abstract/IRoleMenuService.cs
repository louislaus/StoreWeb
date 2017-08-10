using StoreWeb.Services.Pvo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Services.Abstract
{
    public interface IRoleMenuService
    {
        bool Add(RoleMenuPvo loginlog);
        bool Add(List<RoleMenuPvo> models);
        bool Update(RoleMenuPvo loginlog);
        bool Update(IEnumerable<RoleMenuPvo> loginlogs);
        bool Delete(int id);
        bool Delete(Expression<Func<RoleMenuPvo, bool>> exp);
        RoleMenuPvo GetOne(Expression<Func<RoleMenuPvo, bool>> exp);
        List<RoleMenuPvo> Query<OrderKeyType>(Expression<Func<RoleMenuPvo, bool>> Exp, Expression<Func<RoleMenuPvo, OrderKeyType>> orderExp, bool isDesc = true);
        ResultPvo<RoleMenuPvo> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<RoleMenuPvo, bool>> exp, Expression<Func<RoleMenuPvo, OrderKeyType>> orderExp, bool isDesc = true);
        ResultPvo<RoleMenuPvo> GetWithPages(QueryBase queryBase, Expression<Func<RoleMenuPvo, bool>> exp, string orderby, string orderDir = "desc");
    }
}
