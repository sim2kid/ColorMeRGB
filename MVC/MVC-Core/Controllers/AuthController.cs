using Microsoft.AspNetCore.Mvc;

namespace MVC_Core.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }
    }
}
