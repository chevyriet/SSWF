﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DomainServices;
using Microsoft.EntityFrameworkCore;

namespace EB_EF
{
    public class MealBoxEFRepository : IMealBoxRepository
    {
        private readonly EBDbContext _dbContext;

        public MealBoxEFRepository(EBDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<MealBox> Mealboxes => _dbContext.MealBoxes.Include(m => m.Products).Include(m => m.Cantina).ToList();
    }
}