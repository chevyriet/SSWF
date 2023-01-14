using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Rules
{
    public interface IMealBoxReservationService
    {
        bool HasMealBoxAlreadyBeenReserved(MealBox mealBox);

        bool DoesMealBoxAndStudentExist(Student student, MealBox mealBox);

        void ReserveMealBox(Student student, MealBox mealBox, int id);

        bool HasStudentAlreadyReservedMealBoxForThatPickupDay(MealBox mealBox, Student student);

        bool IsStudentOfAge(Student student, MealBox mealBox);
    }
}
