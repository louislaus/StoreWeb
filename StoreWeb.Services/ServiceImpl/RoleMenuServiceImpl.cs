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
    public partial class RoleMenuServiceImpl:BaseService<RoleMenuEntity>,IDependency,IRoleMenuService
    {
        public IDbContextScopeFactory _dbScopeFactory { get; set; }
        public bool Add(List<RoleMenuPvo> models)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entities = Mapper.Map<List<RoleMenuPvo>, List<RoleMenuEntity>>(models);
                dbSet.AddRange(entities);
                return db.SaveChanges() > 0;
            }
        }

        public bool Add(RoleMenuPvo loginlog)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entity = Mapper.Map<RoleMenuPvo, RoleMenuEntity>(loginlog);
                dbSet.Add(entity);
                var count = db.SaveChanges();
                return count > 0;
            }
        }

        public bool Delete(Expression<Func<RoleMenuPvo, bool>> exp)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<RoleMenuPvo, RoleMenuEntity, bool>();
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

        public RoleMenuPvo GetOne(Expression<Func<RoleMenuPvo, bool>> exp)
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<RoleMenuPvo, RoleMenuEntity, bool>();
                var entity = dbSet.AsNoTracking().FirstOrDefault();
                return Mapper.Map<RoleMenuEntity, RoleMenuPvo>(entity);
            }
        }

        public ResultPvo<RoleMenuPvo> GetWithPages(QueryBase queryBase, Expression<Func<RoleMenuPvo, bool>> exp, string orderby, string orderDir = "desc")
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<RoleMenuPvo, RoleMenuEntity, bool>();
                var query = GetQuery(dbSet, where, orderby, orderDir);

                var query_count = query.FutureCount();
                var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
                var list = query_list.ToList();

                var dto = new ResultPvo<RoleMenuPvo>
                {
                    recordsTotal = query_count.Value,
                    data = Mapper.Map<List<RoleMenuEntity>, List<RoleMenuPvo>>(list)
                };
                return dto;
            }
        }

        public ResultPvo<RoleMenuPvo> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<RoleMenuPvo, bool>> exp, Expression<Func<RoleMenuPvo, OrderKeyType>> orderExp, bool isDesc = true)
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<RoleMenuPvo, RoleMenuEntity, bool>();
                var order = orderExp.Cast<RoleMenuPvo, RoleMenuEntity, OrderKeyType>();
                var query = GetQuery(dbSet, where, order, isDesc);

                var query_count = query.FutureCount();
                var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
                var list = query_list.ToList();

                var dto = new ResultPvo<RoleMenuPvo>
                {
                    recordsTotal = query_count.Value,
                    data = Mapper.Map<List<RoleMenuEntity>, List<RoleMenuPvo>>(list)
                };
                return dto;
            }
        }

        public List<RoleMenuPvo> Query<OrderKeyType>(Expression<Func<RoleMenuPvo, bool>> Exp, Expression<Func<RoleMenuPvo, OrderKeyType>> orderExp, bool isDesc = true)
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = Exp.Cast<RoleMenuPvo, RoleMenuEntity, bool>();
                var order = orderExp.Cast<RoleMenuPvo, RoleMenuEntity, OrderKeyType>();
                var query = GetQuery(dbSet, where, order, isDesc);
                var list = query.ToList();
                return Mapper.Map<List<RoleMenuEntity>, List<RoleMenuPvo>>(list);
            }
        }

        public bool Update(IEnumerable<RoleMenuPvo> loginlogs)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entity = Mapper.Map<IEnumerable<RoleMenuPvo>, IEnumerable<RoleMenuEntity>>(loginlogs);
                dbSet.AddOrUpdate(entity.ToArray());
                return db.SaveChanges() > 0;
            }
        }

        public bool Update(RoleMenuPvo loginlog)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entity = Mapper.Map<RoleMenuPvo, RoleMenuEntity>(loginlog);
                dbSet.AddOrUpdate(entity);
                return db.SaveChanges() > 0;
            }
        }
    }
}
