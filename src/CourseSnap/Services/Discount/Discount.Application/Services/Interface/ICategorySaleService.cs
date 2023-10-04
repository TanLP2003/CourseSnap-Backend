using Discount.Application.Models;

namespace Discount.Application.Services.Interface
{
    public interface ICategorySaleService
    {
        Task<CategorySaleModel> GetByCategory(string category);
        Task<CategorySaleModel> Create(CategorySaleModel model);
        Task Update(CategorySaleModel model);
        Task Delete(string category);
    }
}