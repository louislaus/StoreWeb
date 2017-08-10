using StoreWeb.Services.Pvo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Services.Abstract
{
    public interface IUserRoleService
    {
        bool Add(UserRolePvo loginlog);
        bool Add(List<UserRolePvo> models);
        bool Update(UserRolePvo loginlog);
        bool Update(IEnumerable<UserRolePvo> loginlogs);
        bool Delete(int id);
        bool Delete(Expression<Func<UserRolePvo, bool>> exp);
        UserRolePvo GetOne(Expression<Func<UserRolePvo, bool>> exp);
        List<UserRolePvo> Query<OrderKeyType>(Expression<Func<UserRolePvo, bool>> Exp, Expression<Func<UserRolePvo, OrderKeyType>> orderExp, bool isDesc = true);
        ResultPvo<UserRolePvo> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<UserRolePvo, bool>> exp, Expression<Func<UserRolePvo, OrderKeyType>> orderExp, bool isDesc = true);
        ResultPvo<UserRolePvo> GetWithPages(QueryBase queryBase, Expression<Func<UserRolePvo, bool>> exp, string orderby, string orderDir = "desc");
    }
}
