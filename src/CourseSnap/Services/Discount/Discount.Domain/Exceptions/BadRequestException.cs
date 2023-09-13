﻿using Discount.Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Domain.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string message) : base(message) 
        {
        }

        public override int StatusCode => 400;
    }
}
