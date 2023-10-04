using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Domain.Entities
{
    public class CategorySale
    {
        [Key]
        public string Category { get; set; }
        [Required]
        [Column(TypeName ="Date")]
        public DateTime ExpiredAt { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
