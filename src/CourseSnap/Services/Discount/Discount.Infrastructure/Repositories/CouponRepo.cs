using Dapper;
using Discount.Domain.Contracts;
using Discount.Domain.Entities;
using Discount.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infrastructure.Repositories
{
    public class CouponRepo : RepositoryBase<Coupon>, ICouponRepo
    {
        private readonly string _connectionString;
        public CouponRepo(DiscountContext context, IConfiguration configuration) : base(context) 
        {
            _connectionString = configuration.GetConnectionString("MySqlConnection");
        }

        public async Task<Coupon> GetByNameAndCode(string courseName, string code)
        {
            using var connection = new MySqlConnection(_connectionString);
            var command = "SELECT * FROM Coupons WHERE CourseName = @CourseName AND Code = @Code";

            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>(command, new { CourseName = courseName, Code = code});

            return coupon;

        }

        public async Task<bool> CheckCourseName(string courseName)
        {
            using var connection = new MySqlConnection(_connectionString);
            var command = "SELECT * FROM Coupons WHERE CourseName = @CourseName";

            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>(command, new { CourseName = courseName});

            return coupon != null;
        }

        public async Task<bool> CodeExisted(string code)
        {
            using var connection = new MySqlConnection(_connectionString);
            var command = "SELECT * FROM Coupons WHERE Code = @Code";

            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>(command, new {Code = code});
            return coupon != null;  
        }
    }
}
