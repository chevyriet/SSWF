using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Portal.Models
{
    public class LoginViewModel
    {
        [Required]
        public string EmailAddress { get; set; } = null!;

        [Required]
        [UIHint("Password")]
        [PasswordPropertyText]
        public string Password { get; set; } = null!;
    }
}
