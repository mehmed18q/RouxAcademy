using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RouxAcademy.Models.Student;

namespace RouxAcademy.Models.DataServices
{
	public class StudentDataContext(DbContextOptions<StudentDataContext> options) : IdentityDbContext(options)
	{
		public DbSet<CourseGrade> Grades { get; set; }

	}

}
