using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainServices;

namespace EB_EF
{
    public class StudentEFRepository : IStudentRepository
    {
        private readonly EBDbContext _dbContext;

        public StudentEFRepository(EBDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Student? GetStudentByEmail(string EmailAddress)
        {
            return _dbContext.Students.FirstOrDefault(s => s.EmailAddress == EmailAddress);
        }
    }
}