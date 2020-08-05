using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AeriSample.Data.Entity.EntityConfiguration
{
    class ProductCostHistoryConfiguration : IEntityTypeConfiguration<ProductCostHistory>
    {
        public void Configure(EntityTypeBuilder<ProductCostHistory> builder)
        {
            builder.HasKey(e => e.StartDate);
            builder.HasKey(e => e.ProductID);

            builder.ToTable("ProductCostHistory", "production");
            builder.Property(e => e.ProductID);
            builder.Property(e => e.StartDate);
            builder.Property(e => e.EndDate);
            builder.Property(e => e.StandardCost);

        }
    }
}