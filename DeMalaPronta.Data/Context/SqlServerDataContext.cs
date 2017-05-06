using DeMalaPronta.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMalaPronta.Data.Context
{
    public partial class SqlServerDataContext : DbContext, IDataContext
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SqlServerDataContext" /> class using the default connection string
        ///     <code>NotarioVirtualConnection</code>.
        /// </summary>
        public SqlServerDataContext()
            : base("DeMalaProntaConnection")
        {
            this.Database.CommandTimeout = 300;
        }


        public virtual DbSet<Trip> Trip { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Luggage> Luggage { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<User> User{ get; set; }

        /// <summary>
        ///     Creates a new context.
        /// </summary>
        /// <returns>Returns the <see cref="SqlServerDataContext" /> context.</returns>
        public static SqlServerDataContext Create()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SqlServerDataContext, Migrations.Configuration>());
            return new SqlServerDataContext();
        }

        /// <inheritdoc />
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        /// <inheritdoc />
        public int SaveChanges(int timeout)
        {
            var oldTimeout = this.Database.CommandTimeout;
            this.Database.CommandTimeout = timeout;

            var operationCount = this.SaveChanges();

            this.Database.CommandTimeout = oldTimeout;

            return operationCount;
        }

        /// <inheritdoc />
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new TripConfiguration());
            modelBuilder.Configurations.Add(new LuggageConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new ItemConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
