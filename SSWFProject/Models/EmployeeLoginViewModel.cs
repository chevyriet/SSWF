using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Portal.Models
{
    public class EmployeeLoginViewModel
    {
        [Required(ErrorMessage = "Medewerker Nummer veld is verplicht")]
        public string EmployeeNr { get; set; } = null!;

        [Required(ErrorMessage = "Wachtwoord veld is verplicht")]
        [UIHint("Password")]
        [PasswordPropertyText]
        public string Password { get; set; } = null!;
    }
}

