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
    public partial class RoleServiceImpl:BaseService<RoleEntity>,IDependency,IRoleService
    {
        public IDbContextScopeFactory _dbScopeFactory { get; set; }
        public bool Add(List<RolePvo> models)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entities = Mapper.Map<List<RolePvo>, List<RoleEntity>>(models);
                dbSet.AddRange(entities);
                return db.SaveChanges() > 0;
            }
        }

        public bool Add(RolePvo loginlog)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entity = Mapper.Map<RolePvo, RoleEntity>(loginlog);
                dbSet.Add(entity);
                var count = db.SaveChanges();
                return count > 0;
            }
        }

        public bool Delete(Expression<Func<RolePvo, bool>> exp)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<RolePvo, RoleEntity, bool>();
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

        public RolePvo GetOne(Expression<Func<RolePvo, bool>> exp)
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<RolePvo, RoleEntity, bool>();
                var entity = dbSet.AsNoTracking().FirstOrDefault();
                return Mapper.Map<RoleEntity, RolePvo>(entity);
            }
        }

        public ResultPvo<RolePvo> GetWithPages(QueryBase queryBase, Expression<Func<RolePvo, bool>> exp, string orderby, string orderDir = "desc")
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<RolePvo, RoleEntity, bool>();
                var query = GetQuery(dbSet, where, orderby, orderDir);

                var query_count = query.FutureCount();
                var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
                var list = query_list.ToList();

                var dto = new ResultPvo<RolePvo>
                {
                    recordsTotal = query_count.Value,
                    data = Mapper.Map<List<RoleEntity>, List<RolePvo>>(list)
                };
                return dto;
            }
        }

        public ResultPvo<RolePvo> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<RolePvo, bool>> exp, Expression<Func<RolePvo, OrderKeyType>> orderExp, bool isDesc = true)
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<RolePvo, RoleEntity, bool>();
                var order = orderExp.Cast<RolePvo, RoleEntity, OrderKeyType>();
                var query = GetQuery(dbSet, where, order, isDesc);

                var query_count = query.FutureCount();
                var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
                var list = query_list.ToList();

                var dto = new ResultPvo<RolePvo>
                {
                    recordsTotal = query_count.Value,
                    data = Mapper.Map<List<RoleEntity>, List<RolePvo>>(list)
                };
                return dto;
            }
        }

        public List<RolePvo> Query<OrderKeyType>(Expression<Func<RolePvo, bool>> Exp, Expression<Func<RolePvo, OrderKeyType>> orderExp, bool isDesc = true)
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = Exp.Cast<RolePvo, RoleEntity, bool>();
                var order = orderExp.Cast<RolePvo, RoleEntity, OrderKeyType>();
                var query = GetQuery(dbSet, where, order, isDesc);
                var list = query.ToList();
                return Mapper.Map<List<RoleEntity>, List<RolePvo>>(list);
            }
        }

        public bool Update(IEnumerable<RolePvo> loginlogs)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entity = Mapper.Map<IEnumerable<RolePvo>, IEnumerable<RoleEntity>>(loginlogs);
                dbSet.AddOrUpdate(entity.ToArray());
                return db.SaveChanges() > 0;
            }
        }

        public bool Update(RolePvo loginlog)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entity = Mapper.Map<RolePvo, RoleEntity>(loginlog);
                dbSet.AddOrUpdate(entity);
                return db.SaveChanges() > 0;
            }
        }
    }
}
