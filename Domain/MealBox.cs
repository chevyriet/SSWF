using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MealBox
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public City City { get; set; }

        [Required]
        public DateTime? PickupFromTime { get; set; }

        [Required]
        public DateTime? PickupUntilTime { get; set; }

        [Required]
        public bool IsEighteen { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 6)")]
        public decimal Price { get; set; }

        [Required]
        public MealType Type { get; set; }

        public Student? Student { get; set; }

        public Cantina Cantina { get; set; } = null!;

        public ICollection<Product>? Products { get; set; }
    }
}
