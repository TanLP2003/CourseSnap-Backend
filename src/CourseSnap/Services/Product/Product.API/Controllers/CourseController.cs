using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Models;
using Product.Application.Services.Interface;

namespace Product.API.Controllers
{
    [Route("api/Course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{courseName}", Name = "GetByName")]
        public async Task<IActionResult> GetByName(string courseName)
        {
            return Ok(await _service.GetByName(courseName));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CourseCreateModel model)
        {
            if(!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var courseReturnModel = await _service.Add(model);
            return CreatedAtAction("GetByName", new { name = model.Name }, courseReturnModel);
        }

        [HttpPut("{courseId}")]
        [Authorize]
        public async Task<IActionResult> Update(string courseId, [FromBody] CourseUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            await _service.Update(courseId, model);
            return Ok();
        }

        [HttpDelete("{courseName}")]
        [Authorize]
        public async Task<IActionResult> Delete(string courseName)
        {
            await _service.Delete(courseName);
            return Ok();
        }
    }
}
