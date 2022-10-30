using Domain;
using DomainServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EB_WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet("{emailAddress}")]
        public ActionResult<Student> GetStudentByEmail(string emailAddress)
        {
            return Ok(_studentRepository.GetStudentByEmail(emailAddress));
        }
    }
}
