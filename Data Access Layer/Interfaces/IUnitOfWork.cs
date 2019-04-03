using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    interface IUnitOfWork : IDisposable
    {
        IRepository<Customer> Customer { get; }
        IRepository<Order> Orders { get; }
        IRepository<Item> Items { get; }
        IRepository<OrderElement> OrderElements { get; }
        void Save();

    }
}
