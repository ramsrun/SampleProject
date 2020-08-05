using AeriSample.Data.Entity;
using AeriSample.Data.Entity.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AeriSample.Data
{
    public partial class AeriContext : DbContext
    {
        public AeriContext()
        {
        }

        public AeriContext(DbContextOptions<AeriContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCostHistory> ProductCostHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("Server=Ramsharan-PC\\SQLEXPRESS;Database=AdventureWorks2012;user id=sa;password=sa$123;");
            //}
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCostHistoryConfiguration());

        }
    }
}
