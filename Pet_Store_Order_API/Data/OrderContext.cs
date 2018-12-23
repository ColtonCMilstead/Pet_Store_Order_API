using Microsoft.EntityFrameworkCore;
using Pet_Store_Order_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Store_Order_API.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Items> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
