using Hospital_ManagementSystem.Core.Entity.Identity;
using Hospital_ManagementSystem.Core.Services.Contract;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ManagementSystem.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly IConfiguration _configuration;

        public AuthServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
<<<<<<< HEAD
        /// <summary>
        /// Create Token Async
        /// </summary>
        /// <param name="user">object from Patient</param>
        /// <param name="manager">object from UserManger to proivde Api for manage patient </param>
        /// <returns>string token</returns>
=======
<<<<<<< HEAD
>>>>>>> 6d8b2c61e22d9027be0c68d3f088689c50f0f4b6
        public async Task<string> CreateTokenAsync(Patient user, UserManager<Patient> manager)
=======
        /// <summary>
        /// Create Token Async
        /// </summary>
<<<<<<< Updated upstream
        /// <param name="user">An instance of AppUser.</param>
        /// <param name="manager">An instance of UserManager</param>
        /// <returns>string token</returns>
        public async Task<string> CreateTokenAsync(AppUser user, UserManager<AppUser> manager)
=======
        /// <param name="user">object from Patient</param>
        /// <param name="manager">object from UserManger to proivde Api for manage patient </param>
        /// <returns>string token</returns>
        public async Task<string> CreateTokenAsync(Patient user, UserManager<Patient> manager)
>>>>>>> Stashed changes
>>>>>>> feature/Authentication
        {
            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.GivenName,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.NameIdentifier,user.Id)
            };
            var userRole = await manager.GetRolesAsync(user);
            foreach (var role in userRole)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Convert.FromBase64String(_configuration["TokenString:TokenKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(authClaims),
                Audience = _configuration["TokenString:Audience"],
                SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature
            )

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
