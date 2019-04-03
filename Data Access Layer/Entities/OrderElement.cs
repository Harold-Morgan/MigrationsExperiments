using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL.Entities
{
    public class OrderElement
    {
        

        public Guid ID { get; set; }
      //  public Guid ORDER_ID { get; set; }
      //  public Guid ITEM_ID { get; set; }
        [Required]
        public int ITEMS_COUNT { get; set; }
        [Required]
        public Decimal ITEM_PRICE { get; set; }

        public virtual Order Order { get; set; }
        public virtual Item Item { get; set; }
    }
}