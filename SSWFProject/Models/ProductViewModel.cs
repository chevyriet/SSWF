using Domain;
using System.ComponentModel.DataAnnotations;

namespace Portal.Models
{
    public class ProductViewModel
    {
        public Product? Product { get; set; }

        public bool isSelected { get; set; }
    }
}
