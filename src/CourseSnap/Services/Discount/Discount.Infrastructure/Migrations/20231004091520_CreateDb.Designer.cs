﻿// <auto-generated />
using System;
using Discount.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Discount.Infrastructure.Migrations
{
    [DbContext(typeof(DiscountContext))]
    [Migration("20231004091520_CreateDb")]
    partial class CreateDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Discount.Domain.Entities.CategorySale", b =>
                {
                    b.Property<string>("Category")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("ExpiredAt")
                        .HasColumnType("Date");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Category");

                    b.ToTable("Sales");

                    b.HasData(
                        new
                        {
                            Category = "Web",
                            ExpiredAt = new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 50
                        });
                });

            modelBuilder.Entity("Discount.Domain.Entities.Coupon", b =>
                {
                    b.Property<string>("CourseName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("ExpiredAt")
                        .HasColumnType("Date");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("CourseName", "Code");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Coupons");

                    b.HasData(
                        new
                        {
                            CourseName = "Microservice",
                            Code = "asdf",
                            ExpiredAt = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 100
                        },
                        new
                        {
                            CourseName = "Asp.net Core WebAPI",
                            Code = "qwer",
                            ExpiredAt = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 75
                        });
                });
#pragma warning restore 612, 618
        }
    }
}