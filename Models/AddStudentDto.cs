using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StudentRegistrations.Models
{
    public class AddStudentDto
    {
        [DefaultValue("")]
        public string FullName { get; set; }
        
        [EmailAddress]
        [DefaultValue("example@gmail.com")]
        public string Email { get; set; }
    }
}
