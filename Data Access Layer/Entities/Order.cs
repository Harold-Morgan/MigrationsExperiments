using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.Entities
{
    public class Order
    {
        public Guid ID { get; set; }
        // public Guid CUSTOMER_ID { get; set; }
        [Required]
        public DateTime ORDER_DATE { get; set; }
        public DateTime SHIPMENT_DATE { get; set; }
        public long ORDER_NUMBER { get; set; }
        public string STATUS { get; set; }


        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderElement> OrderElements { get; set; }
    }
}