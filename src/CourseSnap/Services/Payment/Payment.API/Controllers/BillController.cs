using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Application.Models;
using Payment.Application.Services;

namespace Payment.API.Controllers
{
    [Route("api/Bill")]
    [ApiController]
    [Authorize]
    public class BillController : ControllerBase
    {
        private readonly IBillService _service;
        public BillController(IBillService service)
        {
            _service = service;
        }

        [HttpGet("{billId}", Name ="GetByBillId")]
        public async Task<IActionResult> GetByBillId(string billId)
        {
            var bill = await _service.GetByBillId(billId);
            return Ok(bill);
        }

        [HttpGet("getByUserName/{userName}", Name = "GetByUserName")]
        public async Task<IActionResult> GetByUserId(string userName)
        {
            var billReturnList = await _service.GetByUserName(userName);    
            return Ok(billReturnList);
        }

        [HttpDelete("getById/{billId}")]
        public async Task<IActionResult> Delete(string billId)
        {
            var result = await _service.Delete(billId);
            return result ? NoContent() : BadRequest("Delete Failed");
        }
    }
}
