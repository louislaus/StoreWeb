using StoreWeb.Core;
using StoreWeb.Entity;
using StoreWeb.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using StoreWeb.Services.Pvo;
using System.Linq.Expressions;
using Mehdime.Entity;
using AutoMapper;
using StoreWeb.Core.Extensions;
using EntityFramework.Extensions;
using System.Data.Entity.Migrations;

namespace StoreWeb.Services.ServiceImpl
{
    public partial class MenuServiceImpl : BaseService<MenuEntity>, IDependency, IMenuService
    {
        public IDbContextScopeFactory _dbScopeFactory { get; set; }
        public bool Add(List<MenuPvo> models)
        {
            using(var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entities=Mapper.Map<List<MenuPvo>,List< MenuEntity >> (models);
                dbSet.AddRange(entities);
                return db.SaveChanges() > 0;
            }
        }

        public bool Add(MenuPvo loginlog)
        {
            using(var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entity = Mapper.Map<MenuPvo, MenuEntity>(loginlog);
                dbSet.Add(entity);
                var count = db.SaveChanges();
                return count > 0;
            }
        }

        public bool Delete(Expression<Func<MenuPvo, bool>> exp)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<MenuPvo, MenuEntity, bool>();
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

        public MenuPvo GetOne(Expression<Func<MenuPvo, bool>> exp)
        {
           using(var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<MenuPvo, MenuEntity, bool>();
                var entity = dbSet.AsNoTracking().FirstOrDefault();
                return Mapper.Map<MenuEntity, MenuPvo>(entity);
            }
        }

        public ResultPvo<MenuPvo> GetWithPages(QueryBase queryBase, Expression<Func<MenuPvo, bool>> exp, string orderby, string orderDir = "desc")
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<MenuPvo, MenuEntity, bool>();
                var query = GetQuery(dbSet, where, orderby, orderDir);

                var query_count = query.FutureCount();
                var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
                var list = query_list.ToList();

                var dto = new ResultPvo<MenuPvo>
                {
                    recordsTotal = query_count.Value,
                    data = Mapper.Map<List<MenuEntity>, List<MenuPvo>>(list)
                };
                return dto;
            }
        }

        public ResultPvo<MenuPvo> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<MenuPvo, bool>> exp, Expression<Func<MenuPvo, OrderKeyType>> orderExp, bool isDesc = true)
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<MenuPvo, MenuEntity, bool>();
                var order = orderExp.Cast<MenuPvo, MenuEntity, OrderKeyType>();
                var query = GetQuery(dbSet, where, order, isDesc);

                var query_count = query.FutureCount();
                var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
                var list = query_list.ToList();

                var dto = new ResultPvo<MenuPvo>
                {
                    recordsTotal = query_count.Value,
                    data = Mapper.Map<List<MenuEntity>, List<MenuPvo>>(list)
                };
                return dto;
            }
        }

        public List<MenuPvo> Query<OrderKeyType>(Expression<Func<MenuPvo, bool>> Exp, Expression<Func<MenuPvo, OrderKeyType>> orderExp, bool isDesc = true)
        {
            using(var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = Exp.Cast<MenuPvo, MenuEntity, bool>();
                var order = orderExp.Cast<MenuPvo, MenuEntity, OrderKeyType>();
                var query = GetQuery(dbSet, where, order, isDesc);
                var list = query.ToList();
                return Mapper.Map<List<MenuEntity>, List<MenuPvo>>(list);
            }
        }

        public bool Update(IEnumerable<MenuPvo> loginlogs)
        {
           using(var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entity = Mapper.Map<IEnumerable<MenuPvo>,IEnumerable<MenuEntity>>(loginlogs);
                dbSet.AddOrUpdate(entity.ToArray());
                return db.SaveChanges() > 0;
            }
        }

        public bool Update(MenuPvo loginlog)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entity = Mapper.Map<MenuPvo ,MenuEntity>(loginlog);
                dbSet.AddOrUpdate(entity);
                return db.SaveChanges() > 0;
            }
        }
    }
}
