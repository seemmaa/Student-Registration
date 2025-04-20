using Microsoft.AspNetCore.Mvc;
using StudentRegistrations.Models;
using StudentRegistrations.Services;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
namespace StudentRegistrations.Controllers

{

    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController:ControllerBase
    {
        public readonly CourseService _courseSevice;
        public CoursesController(CourseService courseService) { 
            _courseSevice = courseService;

        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var result = await _courseSevice.GetAllCourses();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getCourseById(Guid id)
        {
            var result = await _courseSevice.GetCourse(id);
            if (result == null)
            {
                return NotFound("Course not found");
            }
            return Ok(result);
        }
        [HttpPut]

        public async Task<IActionResult> updateCourse(Guid id, AddCourseDto course)
        {
            var result = await _courseSevice.UpdateCourse(id, course);
            if(result == null)
            {
                return NotFound("Course not found");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> createCourse(AddCourseDto course)
        {
            var result = await _courseSevice.AddCourse(course);
            return Ok(result);
        }
        [HttpDelete]

        public async Task<IActionResult> deleteCourse(Guid id)
        {
            var result = await _courseSevice.DeleteCourse(id);
            if(result==null)
            {
                return NotFound("Course not found");
            }
            return Ok(result);
        }

        [HttpGet("get-students-registred-in-a-course")]
        public async Task<IActionResult> getstudentRegInCourse(Guid id)
        {
            var result = await _courseSevice.getStudentRegInCourse(id);
            if(result==null)
            {
                return NotFound("Course not found");
            }
            return Ok(result);
        }
    }
}
