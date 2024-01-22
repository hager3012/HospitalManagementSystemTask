using Hospital_ManagementSystem.Core.Entity.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ManagementSystem.Repository.IdentityData
{
    public class userDbContext:IdentityDbContext<AppUser>
    {
        public userDbContext(DbContextOptions<userDbContext> options):base(options) 
        {
            
        }
    }
}
