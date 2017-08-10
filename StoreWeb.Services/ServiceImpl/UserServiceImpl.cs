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
    public partial class UserServiceImpl:BaseService<UserEntity>,IDependency,IUserService
    {
        public IDbContextScopeFactory _dbScopeFactory { get; set; }
        public bool Add(List<UserPvo> models)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entities = Mapper.Map<List<UserPvo>, List<UserEntity>>(models);
                dbSet.AddRange(entities);
                return db.SaveChanges() > 0;
            }
        }

        public bool Add(UserPvo loginlog)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entity = Mapper.Map<UserPvo, UserEntity>(loginlog);
                dbSet.Add(entity);
                var count = db.SaveChanges();
                return count > 0;
            }
        }

        public bool Delete(Expression<Func<UserPvo, bool>> exp)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<UserPvo, UserEntity, bool>();
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
        public UserPvo GetOne(Expression<Func<UserPvo, bool>> exp)
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<UserPvo, UserEntity, bool>();
                var entity = dbSet.AsNoTracking().FirstOrDefault();
                return Mapper.Map<UserEntity, UserPvo>(entity);
            }
        }

        public ResultPvo<UserPvo> GetWithPages(QueryBase queryBase, Expression<Func<UserPvo, bool>> exp, string orderby, string orderDir = "desc")
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<UserPvo, UserEntity, bool>();
                var query = GetQuery(dbSet, where, orderby, orderDir);

                var query_count = query.FutureCount();
                var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
                var list = query_list.ToList();

                var dto = new ResultPvo<UserPvo>
                {
                    recordsTotal = query_count.Value,
                    data = Mapper.Map<List<UserEntity>, List<UserPvo>>(list)
                };
                return dto;
            }
        }

        public ResultPvo<UserPvo> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<UserPvo, bool>> exp, Expression<Func<UserPvo, OrderKeyType>> orderExp, bool isDesc = true)
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<UserPvo, UserEntity, bool>();
                var order = orderExp.Cast<UserPvo, UserEntity, OrderKeyType>();
                var query = GetQuery(dbSet, where, order, isDesc);

                var query_count = query.FutureCount();
                var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
                var list = query_list.ToList();

                var dto = new ResultPvo<UserPvo>
                {
                    recordsTotal = query_count.Value,
                    data = Mapper.Map<List<UserEntity>, List<UserPvo>>(list)
                };
                return dto;
            }
        }

        public List<UserPvo> Query<OrderKeyType>(Expression<Func<UserPvo, bool>> Exp, Expression<Func<UserPvo, OrderKeyType>> orderExp, bool isDesc = true)
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = Exp.Cast<UserPvo, UserEntity, bool>();
                var order = orderExp.Cast<UserPvo, UserEntity, OrderKeyType>();
                var query = GetQuery(dbSet, where, order, isDesc);
                var list = query.ToList();
                return Mapper.Map<List<UserEntity>, List<UserPvo>>(list);
            }
        }

        public bool Update(IEnumerable<UserPvo> loginlogs)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entity = Mapper.Map<IEnumerable<UserPvo>, IEnumerable<UserEntity>>(loginlogs);
                dbSet.AddOrUpdate(entity.ToArray());
                return db.SaveChanges() > 0;
            }
        }

        public bool Update(UserPvo loginlog)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entity = Mapper.Map<UserPvo, UserEntity>(loginlog);
                dbSet.AddOrUpdate(entity);
                return db.SaveChanges() > 0;
            }
        }
    }
}
