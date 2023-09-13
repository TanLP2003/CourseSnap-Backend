using Microsoft.AspNetCore.Mvc;
using Product.Application.ModelBinder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Product.Application.Models
{
    public class CourseUpdateModel
    {
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        [MaxLength(50)]
        public string Author { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public int Cost { get; set; }
        [Required]
        public decimal Duration { get; set; }
        [Required]
        public int Lectures { get; set; }
    }
}
