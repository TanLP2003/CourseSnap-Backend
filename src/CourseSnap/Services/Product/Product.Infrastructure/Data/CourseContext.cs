using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Product.Domain.Contracts;
using Product.Domain.Entities;

namespace Product.Infrastructure.Data
{
    public class CourseContext : ICourseContext
    {
        public CourseContext(IConfiguration configuration) 
        {
            var dbSettings = configuration.GetSection("CourseDbSettings");
            var mongoClient = new MongoClient(dbSettings["ConnectionString"]);
            var database = mongoClient.GetDatabase(dbSettings["DatabaseName"]);

            Courses = database.GetCollection<Course>(dbSettings["CollectionName"]);
            CourseSeedData.SeedData(Courses);
        }

        public IMongoCollection<Course> Courses { get; set; }
    }
}
