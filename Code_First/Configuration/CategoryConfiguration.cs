using Code_First.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Object Property Model
            builder.Property(x => x.CategoryName).HasMaxLength(15).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(100);

            //Example Data
            List<Category> categories = new List<Category>
            {
                new Category {
                CategoryId = 1,
                CategoryName = "Sebze"
            }};

            //Create Data
            builder.HasData(categories);
        }
    }
}
