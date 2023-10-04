using MongoDB.Driver;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Data
{
    public static class CourseSeedData
    {
        public static void SeedData(IMongoCollection<Course> course)
        {
            bool exist = course.Find(c => true).Any();
            if(!exist)
            {
                course.InsertMany(new List<Course>
                {
                    new Course()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "Microservice",
                    Description = "Microservice architecture with .NET",
                    Category = "web",
                    Author = "Joline Kirsten",
                    Cost = 500,
                    Duration = 20M,
                    Lectures = 15,
                    CreatedAt = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                },
                new Course()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    Name = "Asp.net Core WebAPI",
                    Description = "Build WebAPI with .net",
                    Category = "web",
                    Author = "Eugenie Effie",
                    Cost = 400,
                    Duration = 10M,
                    Lectures = 5,
                    CreatedAt = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                }
                });
            }
        }

        private static List<Course> PreData()
        {
            return new List<Course>()
            {
                new Course()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "Microservice",
                    Description = "Microservice architecture with .NET",
                    Category = "web",
                    Author = "Joline Kirsten",
                    Cost = 500,
                    Duration = 20M,
                    Lectures = 15,
                    CreatedAt = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                },
                new Course()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    Name = "Asp.net Core WebAPI",
                    Description = "Build WebAPI with .net",
                    Category = "web",
                    Author = "Eugenie Effie",
                    Cost = 400,
                    Duration = 10M,
                    Lectures = 5,
                    CreatedAt = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                }
            };
        }
    }
}
