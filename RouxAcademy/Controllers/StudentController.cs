using Microsoft.AspNetCore.Mvc;
using RouxAcademy.Models.DataServices;
using RouxAcademy.Models.Student;

namespace RouxAcademy.Controllers
{
	public class StudentController(ILogger<StudentController> logger, StudentDataContext db) : Controller
	{
		private readonly ILogger<StudentController> _logger = logger;
		private readonly StudentDataContext _db = db;


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

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
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
