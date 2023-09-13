using Microsoft.AspNetCore.Mvc;
using Product.Application.ModelBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Models
{
    public class CourseReturnModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int Cost { get; set; }
        public decimal Duration { get; set; }
        public int Lectures { get; set; }
        public string CreatedAt { get; set; }
        public string LastUpdated { get; set; }
    }
}
