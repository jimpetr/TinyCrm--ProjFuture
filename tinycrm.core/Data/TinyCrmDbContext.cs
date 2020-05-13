using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using tinycrm.core.model;

namespace tinycrm
{
    public class TinyCrmDbContext : DbContext
    {
        private readonly string connectionString =
            "Server =localhost; " +
            "Database =crm--test; " +
            "User Id =sa; " +
            "Password =admin!@#123;";

        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Customer>()
                .ToTable("Customer");

            modelBuilder
                .Entity<Product>()
                .ToTable("Product");

            modelBuilder
                .Entity<Order>()
                .ToTable("Order");

            modelBuilder
                .Entity<OrderProduct>()
                .ToTable("OrderProduct");

            modelBuilder
                .Entity<OrderProduct>()
                .HasKey(op => new { op.ProductId, op.OrderId });
        }
    }
}
