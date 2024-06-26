﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Southwest_Airlines.Data.Models
{
    // extends Asp.Net identityUser
    public class ApplicationUser : IdentityUser
    {
        public virtual Customer? Customer { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
