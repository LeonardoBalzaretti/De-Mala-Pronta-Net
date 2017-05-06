using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMalaPronta.Data.Entities
{
    public class Trip : BaseItemModel
    {
        public int TripId { get; set; }
        public virtual List<Luggage> Luggages { get; set; }
    }
}
