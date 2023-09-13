using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException(string message) : base(message) { }

        public virtual int StatusCode => 500;
    }
}
