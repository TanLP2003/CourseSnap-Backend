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
    public class CouponSeed : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.HasData(
                new Coupon
                { 
                    //CourseId = "64f963965b0a72c6f137062c",
                    CourseName = "Microservice",
                    Code = "asdf",
                    Quantity = 100,
                    ExpiredAt = new DateTime(2023, 12, 31)
                },
                new Coupon
                {
                    //CourseId = "64f964855b0a72c6f137062d",
                    CourseName = "Dotnet Core",
                    Code = "qwer",
                    Quantity = 75,
                    ExpiredAt = new DateTime(2023, 12, 31)
                }
            );
        }
    }
}
