using Microsoft.EntityFrameworkCore;
using StudentRegistrations.Models;

namespace StudentRegistrations.Services
{
    public class RegistrationService
    {
        private readonly MyDbContext _context;
        private readonly StudentService _studentService;
        private readonly CourseService _courseService;
        public RegistrationService(MyDbContext context, StudentService studentService, CourseService courseService) { 
            _context = context;
            _courseService= courseService;
            _studentService = studentService;
        }

        public async Task<string> registerStudent(Guid studentId, Guid courseId)
        {
            var studentExists = await _context.Students.AnyAsync(s => s.Id == studentId);
            if (!studentExists)
                return "Student does not exist";

            var courseExists = await _context.Courses.AnyAsync(c => c.Id == courseId);
            if (!courseExists)
               return "Course does not exist";

            
            var alreadyRegistered = await _context.Registration
                .AnyAsync(r => r.StudentId == studentId && r.CourseId == courseId);

            if (alreadyRegistered)
             return  "Student is already registered for this course";

            var newReg = new Registration {
                Id=Guid.NewGuid(),
                CourseId = courseId,
              StudentId = studentId };
          
            _context.Registration.Add(newReg);
            await _context.SaveChangesAsync();
            return "student registred successfully";
        }

        public async Task<IEnumerable<Registration>> allReg()
        {
            var reg = await _context.Registration.ToListAsync();
            return reg;
        }

        public async Task<Registration> getRegById(Guid id)
        {
           
            var reg = await _context.Registration.FirstOrDefaultAsync(n=>n.Id == id);
            if(reg == null)
            {
                return null;
            }
            return reg;
        }

        public async Task<string> updateReg(Guid id, Guid courseId, Guid studentId)
        {
            var registration = await _context.Registration.FindAsync(id);
            if (registration == null)
                return "Registration not found";

          
            var courseExists = await _context.Courses.AnyAsync(c => c.Id == courseId);
            if (!courseExists)
                return "New course does not exist";

            var studentExists = await _context.Students.AnyAsync(c => c.Id == studentId);
            if (!studentExists)
                return "New student does not exist";

            bool alreadyRegistered = await _context.Registration
                .AnyAsync(r => r.StudentId == registration.StudentId && r.CourseId == courseId && r.Id != id);

            if (alreadyRegistered)
                return "Student is already registered to this course";


            registration.CourseId = courseId;
            registration.StudentId = studentId;
            _context.Registration.Update(registration);
            await _context.SaveChangesAsync();
            return "Registration updated successfully";
        }

        public async Task<string> deleteReg(Guid id)
        {
            var reg = await _context.Registration.FirstOrDefaultAsync(n=>n.Id==id);
            if(reg == null)
            {
                return null;
            }
            _context.Registration.Remove(reg);
            await _context.SaveChangesAsync();
            return "Registration deleted successfully";
        }
    }
}
