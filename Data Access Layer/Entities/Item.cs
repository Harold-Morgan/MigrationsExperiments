using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.Entities
{
    public class Item
    {
        //Разночтение тз? Тем не менее предположим, что таблица "товар" хранит "наименование" товара без указания их кол-ва на складе. 
        //Тогда тут связь одной записи товара ко многим возможным OrderElement - элементам в корзине.
        public Guid ID { get; set; }
        [Required]
        public string CODE { get; set; }
        public string NAME { get; set; }
        public decimal PRICE { get; set; }
        [StringLength(30)] //На категории висит ограничение
        public string CATEGORY { get; set; }

        public virtual ICollection<OrderElement> OrderElements { get; set;}
       
    }
}