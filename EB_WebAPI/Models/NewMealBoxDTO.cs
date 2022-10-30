using Domain;
using System.ComponentModel.DataAnnotations;

namespace EB_WebAPI.Models
{
    public class NewMealBoxDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Naam is verplicht")]
        public string Name { get; set; }

        [Required]
        public City City { get; set; }

        [Required]
        public DateTime? PickupFromTime { get; set; }

        [Required(ErrorMessage = "OphaalDatumTijd is verplicht")]
        public DateTime? PickupUntilTime { get; set; }

        [Required]
        public bool IsEighteen { get; set; }

        [Required(ErrorMessage = "Prijs is verplicht")]
        public double Price { get; set; }

        [Required]
        public MealType Type { get; set; }

        [Required]
        public bool IsWarm { get; set; }

        public int? StudentId { get; set; }
        public Student? Student { get; set; }

        public Cantina Cantina { get; set; } = null!;

        public List<NewProductDTO> Products { get; set; }
    }
}
