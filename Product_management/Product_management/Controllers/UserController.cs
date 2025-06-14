using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_management.Dto;
using Products.DataAccess.Models;
using Products.Services.Services;
using System.IdentityModel.Tokens.Jwt;
using Product_management.Helpers;

namespace Product_management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly JwtHelper _jwtHelper;

        public UserController(UserService userService, JwtHelper jwtHelper)
        {
            _userService = userService;
            _jwtHelper = jwtHelper;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> AddUser(User user)
        {
            await Task.Run(() => _userService.AddUser(user));
            return Ok("User Added!");
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login([FromBody] LoginReqDto dto)
        {
            var user = _userService.Login(dto.Email, dto.Password);

            if (user == null)
            {
                return NotFound("Please check your email & password");
            }

            var token = _jwtHelper.GetJwtToken(user);

            return Ok(new LoginResDto
            {
                Email = user.Email,
                Name = user.Name,
                Role = user.Role,
                Token = token
            });
        }
    }
}
