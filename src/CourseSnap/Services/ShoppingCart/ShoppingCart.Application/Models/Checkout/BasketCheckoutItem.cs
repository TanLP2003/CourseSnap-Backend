using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.Models.Checkout
{
    public class BasketCheckoutItem
    {
        public string? CourseName { get; set; }
        public int Cost { get; set; }
    }
}
