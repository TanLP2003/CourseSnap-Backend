using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Product.Domain.Exceptions.Base
{
    public class BaseException : Exception
    {
        public BaseException(string message) 
            : base(message)
        {
            
        }

        public virtual int StatusCode => 500;
    }
}
