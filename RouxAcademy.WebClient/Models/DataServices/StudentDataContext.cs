using Microsoft.EntityFrameworkCore;
using RouxAcademy.WebClient.Models.Student;

namespace RouxAcademy.WebClient.Models.DataServices
{
    public class StudentDataContext(DbContextOptions<StudentDataContext> options) : DbContext(options)
    {
        public DbSet<CourseGrade> Grades { get; set; }
    }
}
