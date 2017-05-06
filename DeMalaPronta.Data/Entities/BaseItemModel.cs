using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMalaPronta.Data.Entities
{
    public class BaseItemModel
    {
        [Column(TypeName = "VARCHAR")]
        [StringLength(128)]
        [Required]
        public string Title { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        [Required]
        public string ImagePath { get; set; }
    }
}
