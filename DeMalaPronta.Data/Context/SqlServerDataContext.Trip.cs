using DeMalaPronta.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMalaPronta.Data.Context
{
    partial class SqlServerDataContext
    {
        private sealed class TripConfiguration : EntityTypeConfiguration<Trip>
        {
            public TripConfiguration()
            {
            }
        }
    }
}
