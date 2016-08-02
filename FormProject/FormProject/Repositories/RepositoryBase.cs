using FormProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FormProject.Repositories

{
    public class RepositoryBase<TContext> : IDisposable 
        where TContext : DbContext, new()
    {
        private bool _ownDbContext;
        private TContext _dbContext;

        public TContext DbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    _ownDbContext = true;
                    _dbContext = new TContext();
                    _dbContext.Configuration.LazyLoadingEnabled = false;
                    _dbContext.Configuration.AutoDetectChangesEnabled = false;
                    _dbContext.Configuration.ProxyCreationEnabled = false;

                    // If a property is not nullable and unmodified, EF validatation failed because the property could not be null
                    _dbContext.Configuration.ValidateOnSaveEnabled = false;
                }
                return _dbContext;
            }
        }

        public void Dispose()
        {
            if (_ownDbContext == false)
                return;

            if (_dbContext != null)
                _dbContext.Dispose();
        }

        /// <summary>
        /// Ctr
        /// </summary>
        public RepositoryBase()
        {

        }

        /// <summary>
        /// Ctr
        /// </summary>
        /// <param name="repository"></param>
        public RepositoryBase(RepositoryBase<TContext> repository)
        {
            if (repository != null)
                _dbContext = repository.DbContext;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="RepositoryBase"/> class.
        /// </summary>
        ~RepositoryBase()
        {
            Dispose();
        }

        protected PagedDataSource<T> GetPagedDataSource<T>(IQueryable<T> query, int pageIndex, int pageSize = 10)
        {
            var result = new PagedDataSource<T>();

            result.TotalCount = query.Count();
            result.PageSize = pageSize;
            result.PageIndex = pageIndex;

            result.Items = query.Skip(result.PageIndex * result.PageSize)
                                .Take(result.PageSize)
                                .ToList();

            return result;
        }

        protected PagedDataSource<IGrouping<TKey, T>> GetPagedDataSource<T, TKey>(IQueryable<T> query, Expression<Func<T, TKey>> groupBy, int pageIndex, int pageSize = 10)
        {
            var result = new PagedDataSource<IGrouping<TKey, T>>();

            result.TotalCount = query.Count();
            result.PageSize = pageSize;
            result.PageIndex = pageIndex;

            result.Items = query.Skip(result.PageIndex * result.PageSize)
                                .Take(result.PageSize)
                                .GroupBy(groupBy)
                                .ToList();

            return result;
        }

        protected DbEntityEntry<TEntity> MarkAsDelete<TEntity>(DbSet<TEntity> dbSet, TEntity entity) where TEntity : class
        {
            var entry = DbContext.Entry<TEntity>(entity);
            if (entry.State == EntityState.Detached)
                dbSet.Attach(entity);
            entry.State = EntityState.Deleted;
            return entry;
        }

        protected DbEntityEntry<TEntity> MarkAsUpdate<TEntity>(DbSet<TEntity> dbSet, TEntity entity) where TEntity : class
        {
            var entry = DbContext.Entry<TEntity>(entity);
            if (entry.State == EntityState.Detached)
                dbSet.Attach(entity);
            entry.State = EntityState.Modified;
            return entry;
        }

        protected void Add<TEntity>(DbSet<TEntity> dbSet, TEntity entity) where TEntity : class
        {
            dbSet.Add(entity);
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}
