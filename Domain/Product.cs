using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public bool ContainsAlcohol { get; set; }

        [Required]
        public string? ImgUrl { get; set; }

        public ICollection<MealBox>? MealBoxes { get; set; }
    }
}
