using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ManagementSystem.Core.Entity.Identity
{
    public class Patient:IdentityUser
    {
        public string FristName { get; set; }
        public string LastName { get; set; }
    }
}
