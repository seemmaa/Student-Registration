using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistrations.Models
{
    public class CourseDto
    {
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        [Range(1, 5)]
        [DefaultValue(null)]
        public int? Credits { get; set; }
    }
}
