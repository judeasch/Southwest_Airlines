using System;
using System.Collections.Generic;

namespace Southwest_Airlines.Data.Models;

public partial class Login
{
    public string? Username { get; set; }

    public string? Password { get; set; }

    public bool? IsAdmin { get; set; }

    public int LoginId { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
