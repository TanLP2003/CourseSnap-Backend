using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Discount.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    CourseName = table.Column<string>(type: "varchar(255)", nullable: false),
                    Code = table.Column<string>(type: "varchar(255)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => new { x.CourseName, x.Code });
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Category = table.Column<string>(type: "varchar(255)", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "Date", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Category);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Code", "CourseName", "ExpiredAt", "Quantity" },
                values: new object[,]
                {
                    { "qwer", "Asp.net Core WebAPI", new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 75 },
                    { "asdf", "Microservice", new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Category", "ExpiredAt", "Quantity" },
                values: new object[] { "Web", new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 50 });

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_Code",
                table: "Coupons",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "Sales");
        }
    }
}
