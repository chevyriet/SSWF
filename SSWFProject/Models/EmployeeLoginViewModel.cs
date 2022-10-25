using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Portal.Models
{
    public class EmployeeLoginViewModel
    {
        [Required]
        public string EmployeeNr { get; set; } = null!;

        [Required]
        [UIHint("Password")]
        [PasswordPropertyText]
        public string Password { get; set; } = null!;
    }
}

