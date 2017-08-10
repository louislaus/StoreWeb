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
    public partial class UserRoleServiceImpl:BaseService<UserRoleEntity>,IDependency,IUserRoleService
    {
        public IDbContextScopeFactory _dbScopeFactory { get; set; }
        public bool Add(List<UserRolePvo> models)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entities = Mapper.Map<List<UserRolePvo>, List<UserRoleEntity>>(models);
                dbSet.AddRange(entities);
                return db.SaveChanges() > 0;
            }
        }

        public bool Add(UserRolePvo loginlog)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entity = Mapper.Map<UserRolePvo, UserRoleEntity>(loginlog);
                dbSet.Add(entity);
                var count = db.SaveChanges();
                return count > 0;
            }
        }

        public bool Delete(Expression<Func<UserRolePvo, bool>> exp)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<UserRolePvo, UserRoleEntity, bool>();
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

        public UserRolePvo GetOne(Expression<Func<UserRolePvo, bool>> exp)
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<UserRolePvo, UserRoleEntity, bool>();
                var entity = dbSet.AsNoTracking().FirstOrDefault();
                return Mapper.Map<UserRoleEntity, UserRolePvo>(entity);
            }
        }

        public ResultPvo<UserRolePvo> GetWithPages(QueryBase queryBase, Expression<Func<UserRolePvo, bool>> exp, string orderby, string orderDir = "desc")
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<UserRolePvo, UserRoleEntity, bool>();
                var query = GetQuery(dbSet, where, orderby, orderDir);

                var query_count = query.FutureCount();
                var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
                var list = query_list.ToList();

                var dto = new ResultPvo<UserRolePvo>
                {
                    recordsTotal = query_count.Value,
                    data = Mapper.Map<List<UserRoleEntity>, List<UserRolePvo>>(list)
                };
                return dto;
            }
        }

        public ResultPvo<UserRolePvo> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<UserRolePvo, bool>> exp, Expression<Func<UserRolePvo, OrderKeyType>> orderExp, bool isDesc = true)
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<UserRolePvo, UserRoleEntity, bool>();
                var order = orderExp.Cast<UserRolePvo, UserRoleEntity, OrderKeyType>();
                var query = GetQuery(dbSet, where, order, isDesc);

                var query_count = query.FutureCount();
                var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
                var list = query_list.ToList();

                var dto = new ResultPvo<UserRolePvo>
                {
                    recordsTotal = query_count.Value,
                    data = Mapper.Map<List<UserRoleEntity>, List<UserRolePvo>>(list)
                };
                return dto;
            }
        }

        public List<UserRolePvo> Query<OrderKeyType>(Expression<Func<UserRolePvo, bool>> Exp, Expression<Func<UserRolePvo, OrderKeyType>> orderExp, bool isDesc = true)
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = Exp.Cast<UserRolePvo, UserRoleEntity, bool>();
                var order = orderExp.Cast<UserRolePvo, UserRoleEntity, OrderKeyType>();
                var query = GetQuery(dbSet, where, order, isDesc);
                var list = query.ToList();
                return Mapper.Map<List<UserRoleEntity>, List<UserRolePvo>>(list);
            }
        }

        public bool Update(IEnumerable<UserRolePvo> loginlogs)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entity = Mapper.Map<IEnumerable<UserRolePvo>, IEnumerable<UserRoleEntity>>(loginlogs);
                dbSet.AddOrUpdate(entity.ToArray());
                return db.SaveChanges() > 0;
            }
        }

        public bool Update(UserRolePvo loginlog)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entity = Mapper.Map<UserRolePvo, UserRoleEntity>(loginlog);
                dbSet.AddOrUpdate(entity);
                return db.SaveChanges() > 0;
            }
        }
    }
}
