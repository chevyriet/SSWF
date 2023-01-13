using Domain;
using DomainServices;

namespace EB_GraphQL.GraphQL
{
    [ExtendObjectType("Query")]
    public class MealBoxQuery
    {
        private readonly IMealBoxRepository _mealBoxRepository;

        public MealBoxQuery(IMealBoxRepository mealBoxRepository)
        {
            _mealBoxRepository = mealBoxRepository;
        }

        public IEnumerable<MealBox> MealBoxes()
        {
            return _mealBoxRepository.Mealboxes;
        }

        public MealBox? GetMealBoxById(int id)
        {
            return _mealBoxRepository.GetMealBoxById(id);
        }
    }
}
