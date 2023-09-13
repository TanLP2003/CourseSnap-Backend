using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Entities
{
    public class Course
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public int Cost { get; set; }
        public decimal Duration { get; set; }
        public int Lectures { get; set; }
        //[BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
