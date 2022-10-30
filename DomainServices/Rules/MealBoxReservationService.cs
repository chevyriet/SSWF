using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Rules
{
    public class MealBoxReservationService
    {

        private StudentCheckService studentCheckService;

        public MealBoxReservationService(StudentCheckService studentCheckService)
        {
            this.studentCheckService = studentCheckService;
        }

        public bool HasMealBoxAlreadyBeenReserved(MealBox mealBox)
        {
            if(mealBox.StudentId == null)
            {
                return false;
            } else
            {
                return true;
            }
        }

        public bool DoesMealBoxAndStudentExist(Student student, MealBox mealBox)
        {
            if(student == null || mealBox == null)
            {
                return false;
            } else
            {
                return true;
            }

        }

        public bool IsStudentAllowedToReservateMealBox(Student student, MealBox mealBox)
        {
            if(DoesMealBoxAndStudentExist(student, mealBox))
            {
                if (!HasMealBoxAlreadyBeenReserved(mealBox)){
                    if (mealBox.IsEighteen)
                    {
                        if (studentCheckService.IsStudentOfAge(student, mealBox))
                        {
                            return true;
                        } else
                        {
                            return false;
                        }
                    } else
                    {
                        return true;
                    }
                    
                } else
                {
                    return false;
                }
            } else
            {
                return false;
            }
        }
    }
}
