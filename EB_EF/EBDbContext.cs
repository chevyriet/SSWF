using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB_EF
{
    public class EBDbContext : DbContext
    {
        public DbSet<Cantina> Cantinas { get; set; }
        public DbSet<MealBox> MealBoxes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Students { get; set; }

        public EBDbContext(DbContextOptions<EBDbContext> contextOptions) : base(contextOptions)
        {

        }
    }
}
