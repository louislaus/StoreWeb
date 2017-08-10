using AutoMapper;
using EntityFramework.Extensions;
using Mehdime.Entity;
using StoreWeb.Core;
using StoreWeb.Core.Extensions;
using StoreWeb.Entity;
using StoreWeb.Services.Abstract;
using StoreWeb.Services.Pvo;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Services.ServiceImpl
{
    public partial class PageViewServiceImpl:BaseService<PageViewEntity>,IDependency,IPageViewService
    {
        public IDbContextScopeFactory _dbScopeFactory { get; set; }
        public bool Add(List<PageViewPvo> models)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entities = Mapper.Map<List<PageViewPvo>, List<PageViewEntity>>(models);
                dbSet.AddRange(entities);
                return db.SaveChanges() > 0;
            }
        }

        public bool Add(PageViewPvo loginlog)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entity = Mapper.Map<PageViewPvo, PageViewEntity>(loginlog);
                dbSet.Add(entity);
                var count = db.SaveChanges();
                return count > 0;
            }
        }

        public bool Delete(Expression<Func<PageViewPvo, bool>> exp)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<PageViewPvo, PageViewEntity, bool>();
                var models = dbSet.Where(where);
                dbSet.RemoveRange(models);
                var count = db.SaveChanges();
                return count > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var model = dbSet.FirstOrDefault(item => item.Id == id);
                dbSet.Remove(model);
                var count = db.SaveChanges();
                return count > 0;
            }
        }

        public PageViewPvo GetOne(Expression<Func<PageViewPvo, bool>> exp)
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<PageViewPvo, PageViewEntity, bool>();
                var entity = dbSet.AsNoTracking().FirstOrDefault();
                return Mapper.Map<PageViewEntity, PageViewPvo>(entity);
            }
        }

        public ResultPvo<PageViewPvo> GetWithPages(QueryBase queryBase, Expression<Func<PageViewPvo, bool>> exp, string orderby, string orderDir = "desc")
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<PageViewPvo, PageViewEntity, bool>();
                var query = GetQuery(dbSet, where, orderby, orderDir);

                var query_count = query.FutureCount();
                var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
                var list = query_list.ToList();

                var dto = new ResultPvo<PageViewPvo>
                {
                    recordsTotal = query_count.Value,
                    data = Mapper.Map<List<PageViewEntity>, List<PageViewPvo>>(list)
                };
                return dto;
            }
        }

        public ResultPvo<PageViewPvo> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<PageViewPvo, bool>> exp, Expression<Func<PageViewPvo, OrderKeyType>> orderExp, bool isDesc = true)
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<PageViewPvo, PageViewEntity, bool>();
                var order = orderExp.Cast<PageViewPvo, PageViewEntity, OrderKeyType>();
                var query = GetQuery(dbSet, where, order, isDesc);

                var query_count = query.FutureCount();
                var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
                var list = query_list.ToList();

                var dto = new ResultPvo<PageViewPvo>
                {
                    recordsTotal = query_count.Value,
                    data = Mapper.Map<List<PageViewEntity>, List<PageViewPvo>>(list)
                };
                return dto;
            }
        }

        public List<PageViewPvo> Query<OrderKeyType>(Expression<Func<PageViewPvo, bool>> Exp, Expression<Func<PageViewPvo, OrderKeyType>> orderExp, bool isDesc = true)
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = Exp.Cast<PageViewPvo, PageViewEntity, bool>();
                var order = orderExp.Cast<PageViewPvo, PageViewEntity, OrderKeyType>();
                var query = GetQuery(dbSet, where, order, isDesc);
                var list = query.ToList();
                return Mapper.Map<List<PageViewEntity>, List<PageViewPvo>>(list);
            }
        }

        public bool Update(IEnumerable<PageViewPvo> loginlogs)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entity = Mapper.Map<IEnumerable<PageViewPvo>, IEnumerable<PageViewEntity>>(loginlogs);
                dbSet.AddOrUpdate(entity.ToArray());
                return db.SaveChanges() > 0;
            }
        }

        public bool Update(PageViewPvo loginlog)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entity = Mapper.Map<PageViewPvo, PageViewEntity>(loginlog);
                dbSet.AddOrUpdate(entity);
                return db.SaveChanges() > 0;
            }
        }
    }
}
