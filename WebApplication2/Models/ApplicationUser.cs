using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string GroupName { get; set; }
        public string TypeName { get; set; }

    }
}
