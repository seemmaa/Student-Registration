using Microsoft.EntityFrameworkCore;
using StudentRegistrations.Models;

namespace StudentRegistrations.Services
{
    public class CourseService
    {
        private readonly MyDbContext _context;
        public CourseService( MyDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            var courses = await _context.Courses.ToListAsync();
            return courses;
        }

        public async Task<Course> AddCourse(AddCourseDto courseArg)
        {
            var course = new Course
            {
                Id = Guid.NewGuid(),
                CourseName = courseArg.CourseName,
                Credits = courseArg.Credits
            };
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }


        public async Task<Course> GetCourse(Guid id)
        {
           var course = await  _context.Courses.FirstOrDefaultAsync(n => n.Id == id);
            if (course == null)
            {
                return null;
            }
            return course;
        }

        public async Task<Course> UpdateCourse(Guid id, AddCourseDto course)
        {
            var result = await _context.Courses.FirstOrDefaultAsync(n => n.Id == id);
            if (result == null)
            {
                return null;
            }
            if (!(course.CourseName is null)) {
                result.CourseName = course.CourseName; }
            if (!(course.Credits==0)) { 
            result.Credits = course.Credits; }
            
           
            _context.Courses.Update(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<string> DeleteCourse(Guid id)
        {
            var result = await _context.Courses.FirstOrDefaultAsync(n => n.Id == id);
            if (result == null)
            {
                return null;
            }
            _context.Courses.Remove(result);
            await _context.SaveChangesAsync();
            return "Course deleted successfully";
        }

        public async Task<StudentInCourseDto> getStudentRegInCourse(Guid courseId)
        {
            var course = await _context.Courses
         .Where(s => s.Id == courseId)
         .Select(s => new StudentInCourseDto
         {
             courseId = s.Id,
             CourseName = s.CourseName,
             Credits = s.Credits,
            studentRegistred = s.Registrations.Select(r => new Student
             {
                 Id= r.Student.Id,
                 FullName = r.Student.FullName,
                 Email = r.Student.Email
             }).ToList()
         })
         .FirstOrDefaultAsync();
            if (course == null)
            {
                return null;
            }

            return course;
        }
    }
}
