using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RouxAcademy.WebClient.Models.DataServices;
using RouxAcademy.WebClient.Models.Student;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RouxAcademy.WebClient.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly StudentDataContext _db;

        public StudentController(StudentDataContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(new List<CourseGrade>());
        }
        [HttpGet]
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

            _db.Grades.Add(model);
            _db.SaveChanges();

            return RedirectToAction(nameof(StudentController.Index), "Student");
        }
        [HttpGet]
        [AllowAnonymous]
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
