using Code_First.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Code_First.Configuration
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            //Object Property Primary Key
            builder.HasKey(x => new { x.OrderId });

            //Object Relation 
            builder.HasOne(x => x.Product).WithMany(x => x.OrderDetails).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);


            //Object Property Model
            builder.Property(x => x.UnitPrice).HasColumnType("money").IsRequired();
            builder.Property(x => x.Quantity).HasColumnType("smallint").IsRequired();
            builder.Property(x => x.Discount).HasColumnType("float").IsRequired();
        }
    }
}
