using Domain;

namespace Portal.Models
{
    public class ReservedMealBoxesViewModel
    {
        public Student? Student { get; set; }
        public IEnumerable<MealBox>? MealBoxes { get; set; }
    }
}
