using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL
{
    class EFUnitOfWork : IUnitOfWork
    {
        private StoreContext db;

        private CustomerRepository       customerRepository;
        private OrderRepository          orderRepository;
        private ItemRepository           itemRepository;
        private OrderElementRepository   orderElementRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new StoreContext(connectionString);
        }

        public IRepository<Customer> Customer
        {
            get
            {
                if (customerRepository == null)
                    customerRepository = new CustomerRepository(db);
                return customerRepository;
            }
        }


        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }

        public IRepository<Item> Items
        {
            get
            {
                if (itemRepository == null)
                    itemRepository = new ItemRepository(db);
                return itemRepository;
            }
        }

        public IRepository<OrderElement> OrderElements
        {
            get
            {
                if (orderElementRepository == null)
                    orderElementRepository = new OrderElementRepository(db);
                return orderElementRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                disposedValue = true;
            }
        }

        ~EFUnitOfWork() {
           // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
           Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
