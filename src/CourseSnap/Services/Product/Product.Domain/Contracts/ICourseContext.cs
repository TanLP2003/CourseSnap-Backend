﻿using MongoDB.Driver;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Contracts
{
    public interface ICourseContext
    {
        IMongoCollection<Course> Courses { get; }
    }
}
