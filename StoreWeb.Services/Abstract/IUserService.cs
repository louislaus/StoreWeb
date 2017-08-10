using StoreWeb.Services.Pvo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Services.Abstract
{
    public partial interface IUserService
    {
        bool Add(UserPvo loginlog);
        bool Add(List<UserPvo> models);
        bool Update(UserPvo loginlog);
        bool Update(IEnumerable<UserPvo> loginlogs);
        bool Delete(int id);
        bool Delete(Expression<Func<UserPvo, bool>> exp);
        UserPvo GetOne(Expression<Func<UserPvo, bool>> exp);
        List<UserPvo> Query<OrderKeyType>(Expression<Func<UserPvo, bool>> Exp, Expression<Func<UserPvo, OrderKeyType>> orderExp, bool isDesc = true);
        ResultPvo<UserPvo> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<UserPvo, bool>> exp, Expression<Func<UserPvo, OrderKeyType>> orderExp, bool isDesc = true);
        ResultPvo<UserPvo> GetWithPages(QueryBase queryBase, Expression<Func<UserPvo, bool>> exp, string orderby, string orderDir = "desc");
    }
}
