using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMalaPronta.Data.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public virtual List<Trip> Trips { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(128)]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(22)]
        [Required]
        public string Phone { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(128)]
        [Required]
        public string Address { get; set; }
    }
}
