using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ManagementSystem.Core.Entity.Identity
{
    public class AppUser:IdentityUser
    {
        public string fristName { get; set; }
        public string lastName { get; set; }
    }
}
