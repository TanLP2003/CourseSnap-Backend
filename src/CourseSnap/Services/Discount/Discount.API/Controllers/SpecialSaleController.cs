using Discount.Application.Models;
using Discount.Application.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers
{
    [Route("api/Discount/SpecialSale")]
    [ApiController]
    public class SpecialSaleController : ControllerBase
    {
        private readonly IServiceManager _service;

        public SpecialSaleController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("{category}", Name= "GetSpecialSale")]
        public async Task<IActionResult> GetSpecialSale(string category)
        {
            var specialSale = await _service.SpecSale.GetByCategory(category);
            return Ok(specialSale);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecialSale([FromBody] SpecialSaleModel model)
        {
            if(!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var newSpecialSale = await _service.SpecSale.Create(model);
            return CreatedAtAction("GetSpecialSale", new { category = newSpecialSale.Category }, newSpecialSale);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSpecialSale([FromBody] SpecialSaleModel model)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            await _service.SpecSale.Update(model);
            return NoContent();
        }

        [HttpDelete("{category}")]
        public async Task<IActionResult> DeleteSpecialSale(string category)
        {
            await _service.SpecSale.Delete(category);
            return NoContent();
        }
    }
}
