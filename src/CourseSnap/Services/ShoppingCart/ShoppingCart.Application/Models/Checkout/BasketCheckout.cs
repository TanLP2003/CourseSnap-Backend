using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.Models.Checkout
{
    public class BasketCheckout
    {
        [Required]
        public Guid UserId { get; set; }
        public int TotalCost { get; set; }
        public int Tax { get; set; } 
        public int FinalCost { get; set; }
        public List<BasketCheckoutItem>? CartDescription { get; set; }

        public string? Country { get; set; }
        public int PaymentMethod { get; set; }
        public string? CardName { get; set; }
        public string? CardNumber { get; set; }
        public string? CardExpiration { get; set; }
    }
}
