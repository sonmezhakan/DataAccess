using CA_Northwind.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_Northwind.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Eğer ürünlere verilmiş bir kategori, kategori tablosundan silinmeye çalışıldığında hata vermesini sağlar.
            builder.HasOne(p => p.Category).WithMany(p => p.Products).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Restrict);

            //Eğer ürünlere verilmiş bir tedarikçi, tedarikçi tablosundan silinmeye çalıştığında hata vermesini sağlar.
            builder.HasOne(p => p.Supplier).WithMany(p=>p.Products).HasForeignKey(p => p.SupplierId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.ProductName).HasMaxLength(40).IsRequired();
            builder.Property(x => x.QuantityPerUnit).HasMaxLength(20);
            builder.Property(x => x.UnitPrice).HasColumnType("money");
            builder.Property(x => x.UnitsInStock).HasColumnType("smallint");


            List<Product> products = new List<Product> {
            new Product {
                ProductId = 1,
                CategoryId = 1,
                SupplierId = 1,
                ProductName = "Elma",
                QuantityPerUnit = "1kg 1 poşet",
                UnitPrice = 20,
                UnitsInStock = 100
            }
            };


            builder.HasData(products);
        }
    }
}
