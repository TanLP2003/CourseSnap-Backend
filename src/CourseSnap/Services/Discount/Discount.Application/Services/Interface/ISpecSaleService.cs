using Discount.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Services.Interface
{
    public interface ISpecSaleService
    {
        Task<SpecialSaleModel> GetByCategory(string category);
        Task<SpecialSaleModel> Create(SpecialSaleModel model);
        Task Update(SpecialSaleModel model);
        Task Delete(string category);
    }
}
