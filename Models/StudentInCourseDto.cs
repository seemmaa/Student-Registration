using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StudentRegistrations.Models
{
    public class StudentInCourseDto
    {
        public Guid courseId { get; set; } = Guid.NewGuid();

        [DefaultValue("")]
        public string CourseName { get; set; }
        [Range(1, 5)]

        public int Credits { get; set; }

        public List<Student> studentRegistred {  get; set; }
    }
}
