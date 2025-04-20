namespace StudentRegistrations.Models
{
    public class StudentWithCoursesDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }  
        public string Email { get; set; }
        public List<CourseDto> RegisteredCourses { get; set; }
    }
}
