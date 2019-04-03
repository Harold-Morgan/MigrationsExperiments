using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    class ItemRepository : IRepository<Item>
    {
        private StoreContext db;

        public ItemRepository (StoreContext context)
        {
            this.db = context;
        }

        public void Create(Item item)
        {
            db.Items.Add(item);
        }

        public void Delete(Guid id)
        {
            Item item = db.Items.Find(id);
            if (item != null)
                db.Items.Remove(item);
        }

        public IEnumerable<Item> Find(Func<Item, bool> predicate)
        {
            return db.Items.Where(predicate).ToList();
        }

        public Item Get(Guid id)
        {
            return db.Items.Find(id);
        }

        public IEnumerable<Item> GetAll()
        {
            return db.Items;
        }

        public void Update(Item item)
        {
            db.Entry(item).State = EntityState.Modified;
        }


    }
}
