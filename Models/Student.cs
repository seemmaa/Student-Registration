using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace StudentRegistrations.Models
{
    public class Student
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [DefaultValue("")]
        public string FullName { get; set; }
        [DefaultValue("")]
        [EmailAddress]
        public string Email { get; set; }
        [JsonIgnore]
        public ICollection<Registration> Registrations { get; set; }= new List<Registration>();
    }
}
