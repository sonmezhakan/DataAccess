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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.HasOne(x => x.Customer).WithMany(x => x.Orders).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Employee).WithMany(x=>x.Orders).HasForeignKey(x => x.EmployeeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x=>x.Shipper).WithMany(x=>x.Orders).HasForeignKey(x=>x.ShipVia).OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Freigt).HasColumnType("money");
            builder.Property(x => x.ShipName).HasMaxLength(40);
            builder.Property(x => x.ShipAddress).HasMaxLength(60);
            builder.Property(x => x.ShipCity).HasMaxLength(15);
            builder.Property(x => x.ShipRegion).HasMaxLength(15);
            builder.Property(x => x.ShipPostalCode).HasMaxLength(10);
            builder.Property(x => x.ShipCountry).HasMaxLength(15);


        }
    }
}
