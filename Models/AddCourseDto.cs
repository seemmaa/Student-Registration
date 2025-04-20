using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StudentRegistrations.Models
{
    public class AddCourseDto
    {
        [DefaultValue("")]
        public string CourseName { get; set; }
        [Range(1, 5)]
        [DefaultValue(null)]
        public int? Credits { get; set; }
    }
}
