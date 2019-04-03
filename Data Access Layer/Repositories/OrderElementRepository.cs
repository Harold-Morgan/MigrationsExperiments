using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class OrderElementRepository : IRepository<OrderElement>
    {
        private StoreContext db;

        public OrderElementRepository(StoreContext context)
        {
            this.db = context;
        }

        public void Create(OrderElement item)
        {
            db.OrderElements.Add(item);
        }

        public void Delete(Guid id)
        {
            OrderElement item = db.OrderElements.Find(id);
            if (item != null)
                db.OrderElements.Remove(item);
        }

        public IEnumerable<OrderElement> Find(Func<OrderElement, bool> predicate)
        {
            return db.OrderElements.Where(predicate).ToList();
        }

        public OrderElement Get(Guid id)
        {
            return db.OrderElements.Find(id);
        }

        public IEnumerable<OrderElement> GetAll()
        {
            return db.OrderElements;
        }

        public void Update(OrderElement item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
