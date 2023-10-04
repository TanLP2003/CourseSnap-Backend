using Discount.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infrastructure.Data
{
    public class CategorySaleSeed : IEntityTypeConfiguration<CategorySale>
    {
        public void Configure(EntityTypeBuilder<CategorySale> builder)
        {
            builder.HasData
            (
                new CategorySale
                {
                    Category = "Web",
                    ExpiredAt = new DateTime(2023, 10, 30),
                    Quantity = 50
                }
            );
        }
    }
}
