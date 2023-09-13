using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Entities
{
    public class CartItem
    {
        public string? CourseName { get; set; }
        public int Cost { get; set; }
    }
}
