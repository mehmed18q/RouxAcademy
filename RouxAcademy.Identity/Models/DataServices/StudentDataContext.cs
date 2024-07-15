using Microsoft.EntityFrameworkCore;
using RouxAcademy.Models.Student;

namespace RouxAcademy.Models.DataServices
{
	public class StudentDataContext(DbContextOptions<StudentDataContext> options) : DbContext(options)
	{
		public DbSet<CourseGrade> Grades { get; set; }

	}

}
