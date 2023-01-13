using Domain;
using System.ComponentModel.DataAnnotations;

namespace EB_GraphQL.Models
{
    public class NewStudentDTO
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string? StudentNr { get; set; }

        [Required]
        public City City { get; set; }

        [Required]
        [Phone]
        public string? PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string? EmailAddress { get; set; }
    }
}
