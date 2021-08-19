using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCiber.Models.Contexts
{
    public class OrderContext: DbContext
    {
        public DbSet<Customer> Contacts { get; set; }
        public DbSet<Catagory> Catagorys { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }
    }
}
