using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Entities
{
    public class BasketItem
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string Category { get; set; }
        public int Cost { get; set; }
        public decimal Duration { get; set; }
        public string Code { get; set; }
    }
}
