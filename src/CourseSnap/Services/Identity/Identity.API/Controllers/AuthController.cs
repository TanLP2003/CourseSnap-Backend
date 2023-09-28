using Identity.Application.Models;
using Identity.Application.Services;
using Identity.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Register([FromBody] UserRegisterModel userRegisterModel)
        {
            if(!ModelState.IsValid) 
            {
                return UnprocessableEntity(ModelState);
            }
            var result = await _service.RegisterUser(userRegisterModel);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(result);
            }
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel userLoginModel)
        {
            if(!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var token = await _service.Login(userLoginModel);
            return Ok(token);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateModel updateModel)
        {
            var userEmail = await _service.GetUserEmailFromToken(HttpContext);
            await _service.UpdateUser(userEmail, updateModel);
            return NoContent();
        }

        [HttpGet("refresh")]
        public async Task<Token> Refresh()
        {
            var userEmail = await _service.GetUserEmailFromToken(HttpContext);
            var token = await _service.GenerateToken(userEmail);
            return token;
        }
    }
}
