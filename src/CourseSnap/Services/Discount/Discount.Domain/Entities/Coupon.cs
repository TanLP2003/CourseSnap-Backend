﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Domain.Entities
{
    public class Coupon
    {
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [Column(TypeName ="Date")]
        public DateTime ExpiredAt { get; set; }
    }
}
