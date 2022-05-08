using Microsoft.AspNetCore.Mvc;

namespace MVC_Core.Controllers
{
    public class HistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
