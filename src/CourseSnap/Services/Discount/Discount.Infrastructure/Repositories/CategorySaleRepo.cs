using Dapper;
using Discount.Application.Contracts;
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
    public class CategorySaleRepo : RepositoryBase<CategorySale>, ICategorySaleRepo
    {
        private readonly string _connectionString;
        public CategorySaleRepo(DiscountContext context, IConfiguration configuration) : base(context) 
        {
            _connectionString = configuration.GetConnectionString("MySqlConnection");
        }

        public async Task<CategorySale> GetByCategory(string category)
        {
            using var connection = new MySqlConnection(_connectionString);
            var command = "SELECT * FROM Sales WHERE Category = @Category";

            var specSale = await connection.QuerySingleOrDefaultAsync<CategorySale>(command, new { Category = category });
            return specSale;
        }
    }
}
