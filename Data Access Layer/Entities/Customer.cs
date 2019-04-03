using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.Entities
{
    public class Customer
    {
        public Guid ID { get; set; }
        [Required]
        public string NAME { get; set; }
        [Required]
        public string CODE { get; set; }
        public string ADRESS { get; set; }
        public long? DISCOUNT { get; set; } //Потому что null'абле

        public virtual ICollection<Order> Orders { get; set; }
    }
}