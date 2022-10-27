using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB_EF
{
    public class ProductEFRepository : IProductRepository
    {
        private readonly EBDbContext _dbContext;

        public ProductEFRepository(EBDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> Products => _dbContext.Products.Include(p => p.MealBoxes).ToList();
    }
}
