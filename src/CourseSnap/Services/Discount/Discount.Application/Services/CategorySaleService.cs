using AutoMapper;
using Discount.Application.Contracts;
using Discount.Application.Models;
using Discount.Application.Services.Interface;
using Discount.Domain.Entities;
using Discount.Domain.Exceptions;

namespace Discount.Application.Services
{
    public class CategorySaleService : ICategorySaleService
    {
        private readonly IRepoManager _repo;
        private readonly IMapper _mapper;

        public CategorySaleService(IRepoManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CategorySaleModel> GetByCategory(string category)
        {
            var specialSale = await _repo.CategorySale.GetByCategory(category); 

            return _mapper.Map<CategorySaleModel>(specialSale);
        }

        public async Task<CategorySaleModel> Create(CategorySaleModel model)
        {
            var specialSale = await _repo.CategorySale.GetByCategory(model.Category);
            if(specialSale != null)
            {
                throw new BadRequestException($"SpecialSale for category: {model.Category} already exist");
            }
            var newSale = _mapper.Map<CategorySale>(model);
            _repo.CategorySale.Create(newSale);
            await _repo.SaveAsync();

            return model;
        }

        public async Task Update(CategorySaleModel model)
        {
            var specialSale = await _repo.CategorySale.GetByCategory(model.Category);
            if (specialSale == null)
            {
                throw new NotFoundException($"SpecialSale for category: {model.Category} doesn't exist");
            }

            _mapper.Map(model, specialSale);
            _repo.CategorySale.Update(specialSale);
            await _repo.SaveAsync();
        }

        public async Task Delete(string category)
        {
            var specialSale = await _repo.CategorySale.GetByCategory(category);
            if (specialSale == null)
            {
                throw new NotFoundException($"SpecialSale for category: {category} doesn't exist");
            }

            _repo.CategorySale.Delete(specialSale);
            await _repo.SaveAsync();    
        }
    }
}