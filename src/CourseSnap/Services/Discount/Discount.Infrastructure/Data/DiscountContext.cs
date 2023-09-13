using Discount.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infrastructure.Data
{
    public class DiscountContext : DbContext
    {
        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options) 
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CouponSeed());
            modelBuilder.ApplyConfiguration(new SpecialSaleSeed());
            modelBuilder.Entity<Coupon>()
                .HasKey(c => new { c.CourseName, c.Code });
            modelBuilder.Entity<Coupon>()
                .HasIndex(c => c.Code)
                .IsUnique();
            
            /*
            modelBuilder.Entity<Coupon>()
                .Property(c => c.ExpiredAt)
                .HasConversion(
                    v => v.ToString("yyyy-MM-dd"),
                    v => DateTime.ParseExact(v, "yyyy-MM-dd", null)
                );
            */
        }

        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<SpecialSale> Sales { get; set; }
    }
}
