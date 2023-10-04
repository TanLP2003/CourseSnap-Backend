using Discount.Application.Models;
using Discount.Application.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers
{
    [Route("api/Discount/CategorySale")]
    [ApiController]
    public class CategorySaleController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CategorySaleController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("{category}", Name= "GetCategorySale")]
        public async Task<IActionResult> GetCategorySale(string category)
        {
            var specialSale = await _service.CategorySale.GetByCategory(category);
            return Ok(specialSale);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategorySale([FromBody] CategorySaleModel model)
        {
            if(!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var newCategorySale = await _service.CategorySale.Create(model);
            return CreatedAtAction("GetCategorySale", new { category = newCategorySale.Category }, newCategorySale);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategorySale([FromBody] CategorySaleModel model)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            await _service.CategorySale.Update(model);
            return NoContent();
        }

        [HttpDelete("{category}")]
        public async Task<IActionResult> DeleteCategorySale(string category)
        {
            await _service.CategorySale.Delete(category);
            return NoContent();
        }
    }
}
