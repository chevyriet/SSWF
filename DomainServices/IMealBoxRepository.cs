﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DomainServices
{
    public interface IMealBoxRepository
    {
        IEnumerable<MealBox> Mealboxes { get; }
        MealBox? GetMealBoxById(int id); 

        IEnumerable<MealBox> GetMealBoxesByStudentId(int studentId);

        void DeleteMealBox(int id);

        MealBox? CreateMealBox(MealBox mealBox);

        MealBox? EditMealBox(MealBox mealBox);

        MealBox? ReserveMealBox(int id, Student student);

    }
}
