using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Southwest_Airlines.Data.Models;

public class Login : IdentityUser
{
    public bool? IsAdmin { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
