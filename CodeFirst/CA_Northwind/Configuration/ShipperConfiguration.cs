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
    public class ShipperConfiguration : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {
            builder.Property(x => x.CompanyName).HasMaxLength(40).IsRequired();
            builder.Property(x => x.PhoneNumber).HasColumnType("char").HasMaxLength(11);
        }
    }
}
