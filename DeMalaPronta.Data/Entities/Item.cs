using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMalaPronta.Data.Entities
{
    public class Item : BaseItemModel
    {
        public int ItemId { get; set; }

        public Category Category { get; set; }        
    }
}
