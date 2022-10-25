using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB_EF
{
    public class EmployeeEFRepository : IEmployeeRepository
    {
        private readonly EBDbContext _dbContext;

        public EmployeeEFRepository(EBDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Employee? GetEmployeeByNr(string EmployeeNr)
        {
            return _dbContext.Employees.FirstOrDefault(e => e.EmployeeNr == EmployeeNr);
        }
    }
}
