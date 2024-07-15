using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RouxAcademy.Models.DataServices;
using RouxAcademy.Models.Student;

namespace RouxAcademy.Controllers
{
    [Authorize]
    public class StudentController(ILogger<StudentController> logger, StudentDataContext db) : Controller
    {
        private readonly ILogger<StudentController> _logger = logger;
        private readonly StudentDataContext _db = db;


        public IActionResult Index()
        {
            string? userName = User.Identity.Name;
            IQueryable<CourseGrade> grades = _db.Grades.Where(g => g.StudentUsername == userName);
            return View(grades);
        }

        [HttpGet, Authorize(Policy = "FacultyOnly")]
        public IActionResult AddGrade()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGrade(CourseGrade model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            model.CreatedDate = DateTime.Now;
            model.CreatedBy = User.Identity.Name;

            _db.Grades.Add(model);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Classifications()
        {
            List<string> classifications =
            [
                "Freshman",
                "Sophomore",
                "Junior",
                "Senior"
            ];

            return View(classifications);
        }
    }
}
