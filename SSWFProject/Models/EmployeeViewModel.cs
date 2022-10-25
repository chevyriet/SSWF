using Domain;
using System.ComponentModel.DataAnnotations;

namespace Portal.Models
{
    public class EmployeeViewModel
    {
        public Employee? Employee { get; set; }
        public IEnumerable<MealBox> MealBoxes { get; set; } = Enumerable.Empty<MealBox>();

    }
}
