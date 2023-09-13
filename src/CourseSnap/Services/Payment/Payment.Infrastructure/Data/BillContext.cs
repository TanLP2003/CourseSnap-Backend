using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Payment.Application.Contracts;
using Payment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Data
{
    public class BillContext : IBillContext
    {
        public BillContext(IConfiguration configuration) 
        {
            var dbSettings = configuration.GetSection("BillDbSettings");
            var client = new MongoClient(dbSettings["ConnectionString"]);
            var database = client.GetDatabase(dbSettings["DatabaseName"]);

            Bills = database.GetCollection<Bill>(dbSettings["CollectionName"]);
        }

        public IMongoCollection<Bill> Bills { get; set; }
    }
}
