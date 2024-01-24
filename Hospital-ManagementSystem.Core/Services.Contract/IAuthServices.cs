using Hospital_ManagementSystem.Core.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ManagementSystem.Core.Services.Contract
{
    public interface IAuthServices
    {
        /// <summary>
        /// Create token Async
        /// </summary>
        /// <param name="user">An instance of AppUser.</param>
        /// <param name="manager">An instance userManager</param>
        /// <returns>string of token</returns>
        Task<string> CreateTokenAsync(AppUser user,UserManager<AppUser> manager);
    }
}
