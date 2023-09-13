using Payment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Models
{
    public class BillModel
    {
        public string BillId { get; set; }
        public Guid UserId { get; set; }
        public int TotalCost { get; set; }
        public int Tax { get; set; }
        public int FinalCost { get; set; }
        public List<CartItemModel>? CartDescription { get; set; }
        public string? TransactionTime { get; set; }
        public string? Country { get; set; }
        public int PaymentMethod { get; set; }
        public string? CardName { get; set; }
        public string? CardNumber { get; set; }
        public string? Expiration { get; set; }
    }
}
