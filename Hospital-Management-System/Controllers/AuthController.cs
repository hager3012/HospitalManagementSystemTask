using Hospital_Management_System.Dtos;
using Hospital_Management_System.Erorrs;
using Hospital_ManagementSystem.Core.Entity.Identity;
using Hospital_ManagementSystem.Core.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Patient> _userManager;
        private readonly SignInManager<Patient> _signInManager;
        private readonly IAuthServices _authServices;

        public AuthController(UserManager<Patient> userManager,SignInManager<Patient> signInManager,IAuthServices authServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authServices = authServices;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(userRegisterDto userRegister)
        {
            if (EmailExists(userRegister.Email).Result.Value)
                return BadRequest(new ApiValidationResponse(400) { Errors = new string[] {"this email is used"} });
            var user = new Patient
            {
                FristName = userRegister.FristName,
                LastName = userRegister.LastName,
                UserName = userRegister.Email.Split("@")[0],
                Email = userRegister.Email,
                PasswordHash = userRegister.Password

            };
            var result = await _userManager.CreateAsync(user, userRegister.Password);
            if (result.Succeeded is false)
                return BadRequest(new ApiResponse(400));
            return Ok(new UserDto
            {
                Name = user.UserName,
                Email = user.Email,
                Token = await _authServices.CreateTokenAsync(user, _userManager)
            });
        }
        [HttpGet("emailExists")]
        public async Task<ActionResult<bool>> EmailExists(string email)
        {
            return await _userManager.FindByEmailAsync(email) is not null;
        }
        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto userLogin)
        {
            var user = await _userManager.FindByEmailAsync(userLogin.Email);
            if (user is null)
                return Unauthorized(new ApiResponse(401));
            var result = await _userManager.CheckPasswordAsync(user, userLogin.Password);
            if (!result)
                return Unauthorized(new ApiResponse(401));
            return Ok(new UserDto
            {
                Name = user.UserName,
                Email = user.Email,
                Token = await _authServices.CreateTokenAsync(user, _userManager)
            });
        }
    }
}
