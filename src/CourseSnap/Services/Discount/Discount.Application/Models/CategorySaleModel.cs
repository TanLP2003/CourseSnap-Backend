using Discount.Application.ModelBinder;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Discount.Application.Models
{
    public class CategorySaleModel
    {
        [Required]
        public string Category { get; set; }
        [Required]
        [BindProperty(BinderType =typeof(DateTimeBinder))]
        public DateTime ExpiredAt { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}