using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Rules
{
    public class StudentCheckService
    {
        public StudentCheckService()
        {

        }

        public bool IsStudentOfAge(Student student, MealBox mealBox)
        {
            DateTime pickUpDate = mealBox.PickupUntilTime.Value.Date;
            int age = DateTime.Today.Year - student.DateOfBirth.Year;
            if (pickUpDate.Month < student.DateOfBirth.Month || (pickUpDate.Month == student.DateOfBirth.Month && pickUpDate.Day < student.DateOfBirth.Day))
            {
                age--;
            }

            if (age < 18)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
