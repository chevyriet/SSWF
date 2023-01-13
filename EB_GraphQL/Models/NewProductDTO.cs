using Domain;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EB_GraphQL.Models
{
    public class NewProductDTO
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public bool ContainsAlcohol { get; set; }

        [Required]
        public string? ImgUrl { get; set; }

        [JsonIgnore]
        public ICollection<MealBox>? MealBoxes { get; set; }
    }
}
