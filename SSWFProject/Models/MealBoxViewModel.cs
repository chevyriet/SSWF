using Domain;

namespace Portal.Models
{
    public class MealBoxViewModel
    {
        public IEnumerable<MealBox> MealBoxes { get; set; } = Enumerable.Empty<MealBox>();
    }
}
