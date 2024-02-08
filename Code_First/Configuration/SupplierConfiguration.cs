using Code_First.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Code_First.Configuration
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            //Object Property Model
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

            //Example Data
            List<Supplier> suppliers = new List<Supplier>
            {
                new Supplier {
                SupplierId = 1,
                CompanyName = "A Manav",
                ContactName = "Osman Yılmaz",
                ContactTitle = "Deneme",
                Address = "Küçük Yalı Mahallesi",
                City = "İstanbul",
                Region = "Beykoz",
                PostalCode = "340000",
                Country = "Türkiye",
                PhoneNumber = "05555555555",
                Fax = "05555555555"
            }};

            //Create Data
            builder.HasData(suppliers);
        }
    }
}
