﻿using CA_Northwind.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_Northwind.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.CompanyName).HasMaxLength(40).IsRequired();
            builder.Property(x => x.ContactName).HasMaxLength(30);
            builder.Property(x=>x.ContactTitle).HasMaxLength(30);
            builder.Property(x=>x.Address).HasMaxLength(60);
            builder.Property(x => x.City).HasMaxLength(15);
            builder.Property(x=>x.Region).HasMaxLength(15);
            builder.Property(x=>x.PostalCode).HasMaxLength(15);
            builder.Property(x=>x.Country).HasMaxLength(15);
            builder.Property(x => x.Phone).HasColumnType("char").HasMaxLength(11);
            builder.Property(x => x.Fax).HasColumnType("char").HasMaxLength(11);
        }
    }
}
