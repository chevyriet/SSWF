using DomainServices;

namespace EB_GraphQL.GraphQL
{
    [ExtendObjectType("Mutation")]
    public class StudentMutation
    {
        private readonly IStudentRepository _studentRepository;

        public StudentMutation(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

    }
}
