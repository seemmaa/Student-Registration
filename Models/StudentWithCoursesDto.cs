using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistrations.Models
{
    public class StudentWithCoursesDto
    {
        public Guid Id { get; set; }
        [DefaultValue("")]
        public string FullName { get; set; }
        [EmailAddress]
        [DefaultValue("example@gmail.com")]
        public string Email { get; set; }
        public List<CourseDto> RegisteredCourses { get; set; }
    }
}
