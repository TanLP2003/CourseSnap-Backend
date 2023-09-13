using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.Events
{
    public class CheckoutItemEvent
    {
        public string? CourseName { get; set; }
        public int Cost { get; set; }
    }
}
