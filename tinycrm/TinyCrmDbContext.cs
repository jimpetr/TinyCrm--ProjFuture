using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
        }
    }
}
