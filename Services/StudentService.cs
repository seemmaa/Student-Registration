using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRegistrations.Models;
namespace StudentRegistrations.Services


{
    public class StudentService
    {
        private readonly MyDbContext _context;

        public StudentService(MyDbContext context)
        {
            _context = context;
        }
       
        public async Task<IEnumerable< Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync(); ;
        }

        public async Task<Student> AddStudent(AddStudentDto studentArg)
        {
            var student = new Student
            {
                Id = Guid.NewGuid(),
                FullName = studentArg.FullName,
                Email = studentArg.Email
            };
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }


        public async Task<Student> GetStudent(Guid id) {
           var result = await _context.Students.FirstOrDefaultAsync(n => n.Id == id);
            if(result == null)
            {
                return null;
            }
            return result; 
        }

        public async Task<Student> UpdateStudent(Guid id,AddStudentDto updateStudent) {
            var student = await _context.Students.FirstOrDefaultAsync(n => n.Id == id);
            if (student == null)
            {
                return null;
            }
            if (!(updateStudent.FullName is null))
            {
                student.FullName = updateStudent.FullName;
            }
            if (!(updateStudent.Email is null))
            {
                student.Email = updateStudent.Email;
            }
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<string> DeleteStudent(Guid id)
        {
            var result = await _context.Students.FirstOrDefaultAsync(n => n.Id == id);
            if (result == null)
            {
                return null;
            }
            _context.Students.Remove(result);
            await _context.SaveChangesAsync();
            return "Student deleted successfully";
        }
        public async Task<StudentWithCoursesDto> getStudentWithRegCourses(Guid studentId)
        {
            var student = await _context.Students
         .Where(s => s.Id == studentId)
         .Select(s => new StudentWithCoursesDto
         {
             Id = s.Id,
             FullName = s.FullName,
             Email = s.Email,
             RegisteredCourses = s.Registrations.Select(r => new CourseDto
             {
                 CourseId = r.Course.Id,
                 CourseName = r.Course.CourseName,
                 Credits = r.Course.Credits
             }).ToList()
         })
         .FirstOrDefaultAsync();
            if(student == null)
            {
                return null;
            }

            return student;

        }
    }
}
