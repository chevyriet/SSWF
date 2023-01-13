using Domain;
using DomainServices;

namespace EB_GraphQL.GraphQL
{
    [ExtendObjectType("Query")]
    public class StudentQuery
    {
        private readonly IStudentRepository _studentRepository;

        public StudentQuery(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Student? GetStudentByEmail(string EmailAddress)
        {
            return _studentRepository.GetStudentByEmail(EmailAddress);
        }
    }
}
