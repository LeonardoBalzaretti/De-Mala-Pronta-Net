using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMalaPronta.Data.Entities
{
    public class Luggage : BaseItemModel
    {
        public int LuggageId { get; set; }
        public Trip Trip { get; set; }
        public virtual List<Category> Categories { get; set; }
    }
}
