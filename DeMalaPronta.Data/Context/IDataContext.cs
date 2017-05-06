using DeMalaPronta.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMalaPronta.Data.Context
{
    public interface IDataContext : IUnitOfWork, IDisposable
    {
        /// <summary>
        ///     Gets the <see cref="DbEntityEntry" /> of the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity.</typeparam>
        /// <param name="entity">The entity for which the entry should be returned.</param>
        /// <returns>The <see cref="DbEntityEntry" /> of the entity.</returns>
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
