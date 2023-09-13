using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.Events
{
    public class CheckoutEvent
    {
        public Guid UserId { get; set; }
        public int TotalCost { get; set; }
        public int Tax { get; set; }
        public int FinalCost { get; set; }
        public List<CheckoutItemEvent> CartDescription { get; set; }

        public string? Country { get; set; }
        public int PaymentMethod { get; set; }
        public string? CardName { get; set; }
        public string? CardNumber { get; set; }
        public string? CardExpiration { get; set; }
    }
}
