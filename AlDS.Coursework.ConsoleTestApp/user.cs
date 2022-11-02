using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlDS.Coursework.ConsoleTestApp
{
    public class user : IdentityUser
    {
        public int Age { get; set; }

    }
}
