using DeMalaPronta.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeMalaPronta.Data.Repository
{
    /// <summary>
    ///     Basic implementation of a general purpose entity repository.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity that this repository handles.</typeparam>
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private IDataContext context;

        private DbSet<TEntity> dataSet;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Repository{TEntity}" /> class backed by the specified
        ///     <see cref="IDataContext" />.
        /// </summary>
        /// <param name="context">Context used to manipulate database mapped entities.</param>
        public Repository(SqlServerDataContext context)
        {
            this.context = context;
            this.dataSet = context.Set<TEntity>();
        }

        /// <summary>
        ///     Gets the <see cref="SqlServerDatabaseContext" /> used by this repository.
        /// </summary>
        protected IDataContext SqlServerDatabaseContext
        {
            get
            {
                return this.context;
            }
        }

        /// <inheritdoc />
        public virtual IQueryable<TEntity> AsQueryable()
        {
            return this.dataSet;
        }

        public virtual IQueryable<TEntity> AsQueryable(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = this.AsQueryable();

            return IncludeRelationships(includes, query);
        }

        private static IQueryable<TEntity> IncludeRelationships(Expression<Func<TEntity, object>>[] includes, IQueryable<TEntity> query)
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }

        /// <inheritdoc />
        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
            {
                return;
            }

            if (this.context.Entry(entity).State == EntityState.Detached)
            {
                this.dataSet.Attach(entity);
            }

            this.dataSet.Remove(entity);
        }

        /// <inheritdoc />
        public virtual TEntity Find(params object[] entityIdentifiers)
        {
            var entity = this.dataSet.Find(entityIdentifiers);
            return entity;
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> FindAsync(params object[] entityIdentifiers)
        {
            return await this.dataSet.FindAsync(entityIdentifiers);
        }

        /// <inheritdoc />
        public virtual TEntity Insert(TEntity entity)
        {
            return this.dataSet.Add(entity);
        }

        /// <inheritdoc />
        public virtual void Update(TEntity entityToUpdate)
        {
            int i = 0;
            while (true)
            {
                if (this.dataSet.Local.Select(_ => _).Count() <= 0)
                {
                    break;
                }
                this.context.Entry(this.dataSet.Local[i]).State = EntityState.Detached;
            }
            this.context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        /// <inheritdoc />
        public virtual void Update2(TEntity entityToUpdate)
        {
            this.context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
