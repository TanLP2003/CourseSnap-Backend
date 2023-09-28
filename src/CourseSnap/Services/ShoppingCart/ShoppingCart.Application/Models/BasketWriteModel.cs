using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.Models
{
    public class BasketWriteModel
    {
        [Required]
        public string UserName { get; set; }
        public List<BasketItem>? Items { get; set; }
    }
}
