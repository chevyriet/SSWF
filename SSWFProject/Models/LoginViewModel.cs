using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Portal.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email veld is verplicht")]
        public string EmailAddress { get; set; } = null!;

        [Required(ErrorMessage = "Wachtwoord veld is verplicht")]
        [UIHint("Password")]
        [PasswordPropertyText]
        public string Password { get; set; } = null!;
    }
}
