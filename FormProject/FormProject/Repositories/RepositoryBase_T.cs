using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormProject.Repositories

{
    public abstract class RepositoryBase<TContext, TEntity> : RepositoryBase<TContext>
        where TContext : DbContext, new()
        where TEntity : class
    {
        public RepositoryBase()
        {

        }

        public RepositoryBase(RepositoryBase<TContext> repository)
            : base(repository)
        {
        }

        protected virtual DbSet<TEntity> DbSet
        {
            get
            {
                return DbContext.Set<TEntity>();
            }
        }
        
        public void Create(TEntity entity)
        {            
            base.Add(DbSet, entity);
            OnCreating(entity);
            base.SaveChanges();
            OnCreated(entity);
        }

        public void Update(TEntity entity)
        {
            var entry = base.MarkAsUpdate(DbSet, entity);
            OnUpdating(entry);
            base.SaveChanges();
            OnUpdated(entity);
        }

        public TEntity Delete(TEntity entity)
        {
            var entry = base.MarkAsDelete(DbSet, entity);
            OnDeleting(entry);
            base.SaveChanges();
            OnDeleted(entity);
            return entity;
        }


        protected virtual void OnCreating(TEntity entity)
        {
        }

        protected virtual void OnCreated(TEntity entity)
        {
            OnChanged(entity);
        }

        protected virtual void OnUpdating(DbEntityEntry<TEntity> entry)
        {
        }

        protected virtual void OnUpdated(TEntity entity)
        {
            OnChanged(entity);
        }

        protected virtual void OnDeleted(TEntity entity)
        {
            OnChanged(entity);
        }

        protected virtual void OnDeleting(DbEntityEntry<TEntity> entry)
        {
        }
        
        protected virtual void OnChanged(TEntity entity)
        {
        }
    }
}
