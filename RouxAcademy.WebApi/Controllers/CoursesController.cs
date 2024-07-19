using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace RouxAcademy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("RouxAcademy")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string>()
            {
                "Asp.Net Core",
                "Asp.Net MVC",
                "C#",
                "Security"
            };
        }
    }
}