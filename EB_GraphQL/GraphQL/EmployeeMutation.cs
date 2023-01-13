using DomainServices;

namespace EB_GraphQL.GraphQL
{
    [ExtendObjectType("Mutation")]
    public class EmployeeMutation
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeMutation(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

    }
}
