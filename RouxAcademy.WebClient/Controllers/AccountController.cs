using Microsoft.AspNetCore.Mvc;



namespace RouxAcademy.WebClient.Controllers
{
    public class AccountController : Controller
    {

        public AccountController()
        {

        }


        //[HttpPost]
        //public async Task Logout()
        //{
        //    await HttpContext.SignOutAsync("oidc");
        //    await HttpContext.SignOutAsync("Cookie");
        //}

        [HttpPost]
        public IActionResult Logout()
        {
            return new SignOutResult(new string[] { "oidc", "Cookies" });
        }

    }
}
