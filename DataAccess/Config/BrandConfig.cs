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
    public class BrandConfig : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(b => b.BrandID);
            builder.Property(b => b.BrandName).IsRequired().HasMaxLength(100);
            builder.Property(b => b.BrandCode).IsRequired().HasMaxLength(50);

            builder.HasData(
                new Brand { BrandID = 1, BrandName = "Apple", BrandCode = "APL" },
                new Brand { BrandID = 2, BrandName = "Samsung", BrandCode = "SMG" },
                new Brand { BrandID = 3, BrandName = "Huawei", BrandCode = "HUA" },
                new Brand { BrandID = 4, BrandName = "Xiaomi", BrandCode = "XOI" }
            );
        }
    }
}
