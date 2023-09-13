using AutoMapper;
using Discount.Application.Models;
using Discount.Application.Services.Interface;
using Discount.Domain.Contracts;
using Discount.Domain.Entities;
using Discount.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Services
{
    public class SpecSaleService : ISpecSaleService
    {
        private readonly IRepoManager _repo;
        private readonly IMapper _mapper;

        public SpecSaleService(IRepoManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<SpecialSaleModel> GetByCategory(string category)
        {
            var specialSale = await _repo.SpecSale.GetByCategory(category); 

            return _mapper.Map<SpecialSaleModel>(specialSale);
        }

        public async Task<SpecialSaleModel> Create(SpecialSaleModel model)
        {
            var specialSale = await _repo.SpecSale.GetByCategory(model.Category);
            if(specialSale != null)
            {
                throw new BadRequestException($"SpecialSale for category: {model.Category} already exist");
            }
            var newSale = _mapper.Map<SpecialSale>(model);
            _repo.SpecSale.Create(newSale);
            await _repo.SaveAsync();

            return model;
        }

        public async Task Update(SpecialSaleModel model)
        {
            var specialSale = await _repo.SpecSale.GetByCategory(model.Category);
            if (specialSale == null)
            {
                throw new NotFoundException($"SpecialSale for category: {model.Category} doesn't exist");
            }

            _mapper.Map(model, specialSale);
            _repo.SpecSale.Update(specialSale);
            await _repo.SaveAsync();
        }

        public async Task Delete(string category)
        {
            var specialSale = await _repo.SpecSale.GetByCategory(category);
            if (specialSale == null)
            {
                throw new NotFoundException($"SpecialSale for category: {category} doesn't exist");
            }

            _repo.SpecSale.Delete(specialSale);
            await _repo.SaveAsync();    
        }

    }
}
