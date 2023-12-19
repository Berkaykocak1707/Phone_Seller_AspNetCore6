using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Config
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.OrderId);
            builder.Property(o => o.Name).IsRequired().HasMaxLength(50);
            builder.Property(o => o.Line1).IsRequired().HasMaxLength(50);
            builder.Property(o => o.City).IsRequired().HasMaxLength(50);
        }
    }
}
