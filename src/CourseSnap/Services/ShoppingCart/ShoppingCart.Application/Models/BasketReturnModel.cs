using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.Models
{
    public class BasketReturnModel
    {
        public string UserName { get; set; }
        public List<BasketItemReturnModel>? Items { get; set; }

        public int TotalCost { get; set; }
    }
}
