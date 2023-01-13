using Domain;
using System.ComponentModel.DataAnnotations;

namespace EB_GraphQL.Models
{
    public class NewEmployeeDTO
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? EmployeeNr { get; set; }

        public Cantina Cantina { get; set; } = null!;
    }
}
