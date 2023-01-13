using Domain;
using DomainServices;

namespace EB_GraphQL.GraphQL
{
    [ExtendObjectType("Query")]
    public class EmployeeQuery
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeQuery(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee? GetEmployeeByNr(string employeeNr)
        {
            return _employeeRepository.GetEmployeeByNr(employeeNr);
        }
    }
}
