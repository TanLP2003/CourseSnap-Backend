using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Entities
{
    public class Bill
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? BillId { get; set; }
        public string UserName { get; set; }
        public int TotalCost { get; set; }
        public int Tax { get; set; }
        public int FinalCost { get; set; }
        public List<CartItem>? CartDescription { get; set; }
        public string? TransactionTime { get; set; } 
        public string? Country { get; set; }
        public int PaymentMethod { get; set; }
        public string? CardName { get; set; }
        public string? CardNumber { get; set; }
        public string? CardExpiration { get; set; }
    }
}
