using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace DAL.EF
{
    /// <summary>
    /// Unit Of Work == DbContext в терминах Entity Framework
    /// </summary>
    public class StoreContext : DbContext
    {
        public StoreContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderElement> OrderElements { get; set; }
        public DbSet<Item> Items { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Чтоб вместо Items было Item, как написано в MSDN
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}