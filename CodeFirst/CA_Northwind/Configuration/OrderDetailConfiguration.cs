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
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {

            builder.HasKey(x => new {x.OrderId});
            builder.HasOne(x => x.Product).WithMany(x=>x.OrderDetails).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);



            builder.Property(x => x.UnitPrice).HasColumnType("money").IsRequired();
            builder.Property(x => x.Quantity).HasColumnType("smallint").IsRequired();
            builder.Property(x => x.Discount).HasColumnType("float").IsRequired();
        }
    }
}
