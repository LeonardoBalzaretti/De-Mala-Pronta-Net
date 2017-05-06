using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMalaPronta.Data.Entities
{
    public class Category : BaseItemModel
    {
        public int CategoryId { get; set; }
        public Luggage Luggage { get; set; }
        public virtual List<Item> Items { get; set; }
    }
}
