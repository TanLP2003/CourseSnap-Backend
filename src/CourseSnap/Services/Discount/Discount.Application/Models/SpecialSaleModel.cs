using Discount.Application.ModelBinder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Models
{
    public class SpecialSaleModel
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
