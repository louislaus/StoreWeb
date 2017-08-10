using StoreWeb.Services.Pvo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Services.Abstract
{
    public partial interface IPageViewService
    {
        bool Add(PageViewPvo loginlog);
        bool Add(List<PageViewPvo> models);
        bool Update(PageViewPvo loginlog);
        bool Update(IEnumerable<PageViewPvo> loginlogs);
        bool Delete(int id);
        bool Delete(Expression<Func<PageViewPvo, bool>> exp);
        PageViewPvo GetOne(Expression<Func<PageViewPvo, bool>> exp);
        List<PageViewPvo> Query<OrderKeyType>(Expression<Func<PageViewPvo, bool>> Exp, Expression<Func<PageViewPvo, OrderKeyType>> orderExp, bool isDesc = true);
        ResultPvo<PageViewPvo> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<PageViewPvo, bool>> exp, Expression<Func<PageViewPvo, OrderKeyType>> orderExp, bool isDesc = true);
        ResultPvo<PageViewPvo> GetWithPages(QueryBase queryBase, Expression<Func<PageViewPvo, bool>> exp, string orderby, string orderDir = "desc");
    }
}
