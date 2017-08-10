using StoreWeb.Services.Pvo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Services.Abstract
{
    public partial interface IMenuService
    {
        bool Add(MenuPvo loginlog);
        bool Add(List<MenuPvo> models);
        bool Update(MenuPvo loginlog);
        bool Update(IEnumerable<MenuPvo> loginlogs);
        bool Delete(int id);
        bool Delete(Expression<Func<MenuPvo, bool>> exp);
        MenuPvo GetOne(Expression<Func<MenuPvo, bool>> exp);
        List<MenuPvo> Query<OrderKeyType>(Expression<Func<MenuPvo, bool>> Exp, Expression<Func<MenuPvo, OrderKeyType>> orderExp, bool isDesc = true);
        ResultPvo<MenuPvo> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<MenuPvo, bool>> exp, Expression<Func<MenuPvo, OrderKeyType>> orderExp, bool isDesc = true);
        ResultPvo<MenuPvo> GetWithPages(QueryBase queryBase, Expression<Func<MenuPvo, bool>> exp, string orderby, string orderDir = "desc");
    }
}
