using StoreWeb.Services.Pvo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Services.Abstract
{
    public partial interface IRoleService
    {
        bool Add(RolePvo loginlog);
        bool Add(List<RolePvo> models);
        bool Update(RolePvo loginlog);
        bool Update(IEnumerable<RolePvo> loginlogs);
        bool Delete(int id);
        bool Delete(Expression<Func<RolePvo, bool>> exp);
        RolePvo GetOne(Expression<Func<RolePvo, bool>> exp);
        List<RolePvo> Query<OrderKeyType>(Expression<Func<RolePvo, bool>> Exp, Expression<Func<RolePvo, OrderKeyType>> orderExp, bool isDesc = true);
        ResultPvo<RolePvo> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<RolePvo, bool>> exp, Expression<Func<RolePvo, OrderKeyType>> orderExp, bool isDesc = true);
        ResultPvo<RolePvo> GetWithPages(QueryBase queryBase, Expression<Func<RolePvo, bool>> exp, string orderby, string orderDir = "desc");
    }
}
