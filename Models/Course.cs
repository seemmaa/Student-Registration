using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StudentRegistrations.Models
{
    public class Course
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [DefaultValue("")]
       public string CourseName { get; set; }
        [Range(1, 5)]
        [DefaultValue(null)]
       public int? Credits { get; set; }
        [JsonIgnore]
        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
