using Discount.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Domain.Contracts
{
    public interface ISpecSaleRepo : IBaseRepo<SpecialSale>
    {
        Task<SpecialSale> GetByCategory(string category);
    }
}
