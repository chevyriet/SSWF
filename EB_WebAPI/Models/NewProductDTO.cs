using Domain;
using System.ComponentModel.DataAnnotations;

namespace EB_WebAPI.Models
{
    public class NewProductDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public bool ContainsAlcohol { get; set; }

        [Required]
        public string? ImgUrl { get; set; }

    }
}
