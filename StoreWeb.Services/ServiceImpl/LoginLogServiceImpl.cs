using StoreWeb.Core;
using StoreWeb.Entity;
using StoreWeb.Services.Abstract;
using System;
using System.Collections.Generic;
using StoreWeb.Services.Pvo;
using System.Linq.Expressions;
using Mehdime.Entity;
using AutoMapper;
using System.Data.Entity.Migrations;
using System.Linq;
using StoreWeb.Core.Extensions;
using EntityFramework.Extensions;

namespace StoreWeb.Services.ServiceImpl
{
    public class LoginLogServiceImpl : BaseService<LoginLogEntity>, IDependency, ILoginLogService
    {
        public IDbContextScopeFactory _dbScopeFactory { get; set; }
        public bool Add(List<LoginLogPvo> models)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entity = Mapper.Map<List<LoginLogPvo>,List< LoginLogEntity>>(models);
                dbSet.AddRange(entity);
                var count = db.SaveChanges();
                return count > 0;
            }
        }

        public bool Add(LoginLogPvo loginlog)
        {
           using(var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entity = Mapper.Map<LoginLogPvo, LoginLogEntity>(loginlog);
                dbSet.Add(entity);
                var count = db.SaveChanges();
                return count > 0;
            }
        }

        public bool Delete(Expression<Func<LoginLogPvo, bool>> exp)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<LoginLogPvo, LoginLogEntity, bool>();
                var entities = dbSet.Where(where);
                dbSet.RemoveRange(entities);
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
                var entity = dbSet.FirstOrDefault(item => item.Id == id);
                dbSet.Remove(entity);
                var count = db.SaveChanges();
                return count > 0;
            }
        }

        public LoginLogPvo GetOne(Expression<Func<LoginLogPvo, bool>> exp)
        {
            using(var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<LoginLogPvo, LoginLogEntity, bool>();
                var entity = dbSet.AsNoTracking().FirstOrDefault(where);
                return Mapper.Map<LoginLogEntity, LoginLogPvo>(entity);
            }
        }

        public ResultPvo<LoginLogPvo> GetWithPages(QueryBase queryBase, Expression<Func<LoginLogPvo, bool>> exp, string orderby, string orderDir = "desc")
        {
           using(var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<LoginLogPvo, LoginLogEntity, bool>();
                var query = GetQuery(dbSet, where, orderby, orderDir);
                var query_count = query.FutureCount();
                var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
                var list = query_list.ToList();
                var pvo = new ResultPvo<LoginLogPvo>
                {
                    recordsTotal = query_count.Value,
                    data = Mapper.Map<List<LoginLogEntity>, List<LoginLogPvo>>(list)
                };
                return pvo;
            }
        }

        public ResultPvo<LoginLogPvo> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<LoginLogPvo, bool>> exp, Expression<Func<LoginLogPvo, OrderKeyType>> orderExp, bool isDesc = true)
        {
           using(var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = exp.Cast<LoginLogPvo, LoginLogEntity, bool>();
                var order = orderExp.Cast<LoginLogPvo, LoginLogEntity, OrderKeyType>();
                var query = GetQuery(dbSet, where, order, isDesc);
                var query_count = query.FutureCount();
                var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
                var list = query_list.ToList();
                var pvo = new ResultPvo<LoginLogPvo>
                {
                    recordsTotal = query_count.Value,
                    data = Mapper.Map<List<LoginLogEntity>, List<LoginLogPvo>>(list)
                };
                return pvo; 
            }
        }

        public List<LoginLogPvo> Query<OrderKeyType>(Expression<Func<LoginLogPvo, bool>> Exp, Expression<Func<LoginLogPvo, OrderKeyType>> orderExp, bool isDesc = true)
        {
            using(var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var where = Exp.Cast<LoginLogPvo, LoginLogEntity, bool>();
                var order = orderExp.Cast<LoginLogPvo, LoginLogEntity, OrderKeyType>();
                var query = GetQuery(dbSet, where, order, isDesc);
                var list = query.ToList();
                return Mapper.Map<List<LoginLogEntity>, List<LoginLogPvo>>(list);
            }
        }

        public bool Update(IEnumerable<LoginLogPvo> loginlogs)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entity = Mapper.Map<IEnumerable<LoginLogPvo>, IEnumerable< LoginLogEntity>>(loginlogs);
                dbSet.AddOrUpdate(entity.ToArray());
                var count = db.SaveChanges();
                return count > 0;
            }
        }

        public bool Update(LoginLogPvo loginlog)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var entity = Mapper.Map<LoginLogPvo, LoginLogEntity>(loginlog);
                dbSet.AddOrUpdate(entity);
                var count = db.SaveChanges();
                return count > 0;
            }
        }
    }
}
