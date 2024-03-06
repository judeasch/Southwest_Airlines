using System.ComponentModel.DataAnnotations;

namespace Southwest_Airlines.Models
{
    public class LoginModel
    {
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; } // todo: make this functional on localhost
        public string? ReturnUrl { get; set; }
    }
}
