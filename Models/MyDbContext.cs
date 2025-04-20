using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentRegistrations.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; } = null!;

        public DbSet<Course> Courses { get; set; }= null!;

        public DbSet<Registration> Registration { get; set; } = null!;
    }

}
