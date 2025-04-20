using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace StudentRegistrations.Models
{
    public class Registration
    {
        public Guid Id { get; set; } = Guid.NewGuid();



        public Guid StudentId { get; set; }
       
       
        public Guid CourseId { get; set; }

        public DateTime RegisteredOn { get; set; } = DateTime.Now;

        [JsonIgnore]
        public Student Student { get; set; }
        [JsonIgnore]
        public Course Course { get; set; }
    }
}
