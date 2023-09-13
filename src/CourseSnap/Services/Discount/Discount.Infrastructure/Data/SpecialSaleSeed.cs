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
    public class SpecialSaleSeed : IEntityTypeConfiguration<SpecialSale>
    {
        public void Configure(EntityTypeBuilder<SpecialSale> builder)
        {
            builder.HasData
            (
                new SpecialSale
                {
                    Category = "Web",
                    ExpiredAt = new DateTime(2023, 10, 1),
                    Quantity = 50
                }
            );
        }
    }
}
