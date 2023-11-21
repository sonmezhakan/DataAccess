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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.Property(x => x.CategoryName).HasMaxLength(15).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(100);

            List<Category> categories = new List<Category>
            {
                new Category {
                CategoryId = 1,
                CategoryName = "Sebze"
            }
            };

            builder.HasData(categories);

        }
    }
}
