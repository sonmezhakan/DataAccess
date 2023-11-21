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
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(x => x.CompanyName).HasMaxLength(40).IsRequired();
            builder.Property(x => x.ContactName).HasMaxLength(30);
            builder.Property(x => x.ContactTitle).HasMaxLength(30);
            builder.Property(x => x.Address).HasMaxLength(60);
            builder.Property(x => x.City).HasMaxLength(15);
            builder.Property(x => x.Region).HasMaxLength(15);
            builder.Property(x => x.PostalCode).HasMaxLength(15);
            builder.Property(x => x.Country).HasMaxLength(15);
            builder.Property(x => x.PhoneNumber).HasColumnType("char").HasMaxLength(11);
            builder.Property(x => x.Fax).HasColumnType("char").HasMaxLength(11);

            List<Supplier> suppliers = new List<Supplier>
            {
                new Supplier {
                SupplierId = 1,
                CompanyName = "A Manav",
                ContactName = "Osman Yılmaz",
                ContactTitle = "Deneme",
                Address = "Küçük Yalı Mahallesi",
                City = "İstanbul",
                Region = "Küçükçekmece",
                PostalCode = "340000",
                Country = "Türkiye",
                PhoneNumber = "05552221133",
                Fax = "05552221133"
            }};


            builder.HasData(suppliers);
        }
    }
}
