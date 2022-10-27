using Domain;

namespace Portal.Models
{
    public class CreateUpdateMealBoxViewModel
    {
        public MealBox? MealBox { get; set; }

        public IList<ProductViewModel> ProductViewModels { get; set; }
    }
}
