
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using StoreWeb.Services.Pvo;

namespace StoreWeb.Services.Abstract
{
    public partial interface ILoginLogService
    {
        bool Add(LoginLogPvo loginlog);
        bool Add(List<LoginLogPvo> models);
        bool Update(LoginLogPvo loginlog);
        bool Update(IEnumerable<LoginLogPvo> loginlogs);
        bool Delete(int id);
        bool Delete(Expression<Func<LoginLogPvo, bool>> exp);
        LoginLogPvo GetOne(Expression<Func<LoginLogPvo, bool>> exp);
        List<LoginLogPvo> Query<OrderKeyType>(Expression<Func<LoginLogPvo,bool>> Exp,Expression<Func<LoginLogPvo,OrderKeyType>> orderExp,bool isDesc=true);
        ResultPvo<LoginLogPvo> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<LoginLogPvo, bool>> exp, Expression<Func<LoginLogPvo, OrderKeyType>> orderExp, bool isDesc = true);
        ResultPvo<LoginLogPvo> GetWithPages(QueryBase queryBase, Expression<Func<LoginLogPvo, bool>> exp, string orderby, string orderDir = "desc");
    }
}
