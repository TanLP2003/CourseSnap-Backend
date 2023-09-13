using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Entities
{
    public class Basket
    {
        [Required]
        public Guid UserId { get; set; }
        public List<BasketItem>? Items { get; set; }

        public int TotalCost
        {
            get
            {
                int result = 0;
                foreach (var item in Items)
                {
                    result += item.Cost;
                }
                return result;
            }
        }
    }
}
