using Code_First.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Code_First.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Object Relation 
            builder.HasOne(p => p.Category).WithMany(p => p.Products).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Supplier).WithMany(p => p.Products).HasForeignKey(p => p.SupplierId).OnDelete(DeleteBehavior.Restrict);

            //Object Property Model
            builder.Property(x => x.ProductName).HasMaxLength(40).IsRequired();
            builder.Property(x => x.QuantityPerUnit).HasMaxLength(20);
            builder.Property(x => x.UnitPrice).HasColumnType("money");
            builder.Property(x => x.UnitsInStock).HasColumnType("smallint");

            //Example Data
            List<Product> products = new List<Product> {
            new Product {
                ProductId = 1,
                CategoryId = 1,
                SupplierId = 1,
                ProductName = "Elma",
                QuantityPerUnit = "1kg 1 poşet",
                UnitPrice = 20,
                UnitsInStock = 100
            }};

            //Create Data
            builder.HasData(products);
        }
    }
}
