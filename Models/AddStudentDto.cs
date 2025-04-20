using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StudentRegistrations.Models
{
    public class AddStudentDto
    {
        [DefaultValue("")]
        public string FullName { get; set; }
        [DefaultValue("")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
