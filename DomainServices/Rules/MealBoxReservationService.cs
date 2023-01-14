using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Rules
{
    public class MealBoxReservationService: IMealBoxReservationService
    {

        private readonly IMealBoxRepository _mealBoxRepository;
        private readonly IStudentRepository _studentRepository;

        public MealBoxReservationService(IMealBoxRepository mealBoxRepository, IStudentRepository studentRepository)
        {
            _mealBoxRepository = mealBoxRepository;
            _studentRepository = studentRepository;
        }

        public bool HasMealBoxAlreadyBeenReserved(MealBox mealBox)
        {

            if(mealBox.StudentId == null)
            {
                return false;
            } else
            {
                throw new Exception("Pakket is ondertussen al gereserveerd, kan niet reserveren");
            }
        }

        public bool HasStudentAlreadyReservedMealBoxForThatPickupDay(MealBox mealBox, Student student)
        {

            if (_mealBoxRepository.GetMealBoxesByStudentId(student.Id).Where(m => m.PickupFromTime.Value.Date.Equals(DateTime.Now.Date)).Count() > 0)
            {
                throw new Exception("Kan niet meer dan 1 pakket per ophaaldag reserveren!");
            }
            else
            {
                return false;
            }
        }

        public bool DoesMealBoxAndStudentExist(Student student, MealBox mealBox)
        {
            if(student == null || mealBox == null)
            {
                throw new Exception("Pakket of Student bestaat niet");
            } else
            {
                return true;
            }

        }

        public bool IsStudentOfAge(Student student, MealBox mealBox)
        {
            if (mealBox.IsEighteen)
            {
                DateTime pickUpDate = mealBox.PickupUntilTime.Value.Date;
                int age = DateTime.Today.Year - student.DateOfBirth.Year;
                if (pickUpDate.Month < student.DateOfBirth.Month || (pickUpDate.Month == student.DateOfBirth.Month && pickUpDate.Day < student.DateOfBirth.Day))
                {
                    age--;
                }

                if (age < 18)
                {
                    throw new Exception("Moet 18+ zijn om dit pakket te kunnen reserveren");
                }
                else
                {
                    return true;
                }
            } else
            {
                return true;
            }

        }

        public void ReserveMealBox(Student student, MealBox mealBox, int id)
        {
            try
            {
                if (DoesMealBoxAndStudentExist(student, mealBox))
                {
                    if (!HasMealBoxAlreadyBeenReserved(mealBox))
                    {
                        if (!HasStudentAlreadyReservedMealBoxForThatPickupDay(mealBox, student))
                        {
                            if (IsStudentOfAge(student, mealBox))
                            {
                                _mealBoxRepository.ReserveMealBox(id, student);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
