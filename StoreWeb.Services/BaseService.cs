using Mehdime.Entity;
using StoreWeb.Data;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using StoreWeb.Core.Extensions;

namespace StoreWeb.Services
{
    public abstract class BaseService<T> where T:class
    {
        protected DbContext GetDb(IDbContextScope scope)
        {
            return scope.DbContexts.Get<StoreContext>();
        }
        protected DbContext GetDb(IDbContextReadOnlyScope scope)
        {
            return scope.DbContexts.Get<StoreContext>();
        }
        protected DbSet<T> GetDbSet(DbContext db)
        {
            return db.Set<T>();
        }
        protected IQueryable<T> GetQuery<OrderKeyType>(DbSet<T> dbSet,Expression<Func<T,bool>> exp,Expression<Func<T,OrderKeyType>> orderExp,bool isDesc = true)
        {
            var query = dbSet.AsNoTracking().OrderByDescending(orderExp).Where(exp);
            if (!isDesc)
                query = dbSet.AsNoTracking().OrderBy(orderExp).Where(exp);
            return query;
        }
        protected IQueryable<T> GetQuery(DbSet<T> dbSet,Expression<Func<T,bool>> exp,string orderby,string orderDir)
        {
            var query = dbSet.AsNoTracking().OrderBy(orderby, orderDir).Where(exp);
            return query;
        }
        protected IQueryable<T> GetQuery<InCludeKeyType,OrderKeyType>(DbSet<T> dbSet,Expression<Func<T,InCludeKeyType>>includeExp,Expression<Func<T,bool>>exp,Expression<Func<T,OrderKeyType>> orderExp,bool isDesc = true)
        {
            var query = dbSet.AsNoTracking().Include(includeExp).OrderByDescending(orderExp).Where(exp);
            if(!isDesc)
                query = dbSet.AsNoTracking().Include(includeExp).OrderBy(orderExp).Where(exp);
            return query;
        }
        protected IQueryable<T> GetQuery<IncludeKeyType>(DbSet<T> dbSet,Expression<Func<T,IncludeKeyType>> includeExp,Expression<Func<T,bool>> exp,string orderBy,string orderDir)
        {
            var query = dbSet.AsNoTracking().Include(includeExp).OrderBy(orderBy, orderDir).Where(exp);
            return query;
        }
    }
}
