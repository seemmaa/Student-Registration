using Microsoft.AspNetCore.Mvc;
using StudentRegistrations.Services;
using StudentRegistrations.Models;

namespace StudentRegistrations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase

    {
        private readonly StudentService _studentService;
        public StudentsController(StudentService studentService) {
            _studentService = studentService;
        }
        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            return Ok(await _studentService.GetAllStudents());
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent( AddStudentDto student)
        {
            var result = await _studentService.AddStudent(student);
            if (result == null)
            {
                return NotFound("student not found");
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getStudentById(Guid id)
        {
            var result = await _studentService.GetStudent(id);
            if (result == null)
                return NotFound("student not found");
          
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> updateStudent(Guid id,  AddStudentDto student)
        {
            var result = await _studentService.UpdateStudent(id, student);
            if(result==null)
            {
                return NotFound("Student not found");
            }
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent (Guid id)
        {
            var result = await _studentService.DeleteStudent(id);
            if(result==null)
            {
                return NotFound("Student not found");
            }
            return Ok(result);
        }

        [HttpGet("student-registred-courses")]
        public async Task<IActionResult> studentReg(Guid id)
        {
            var result = await _studentService.getStudentWithRegCourses(id);
            if(result == null)
            {
                return NotFound("Student not found");
            }
            return Ok(result);
        }

    }
}
