using Microsoft.AspNetCore.Mvc;

// Written by Owen Ravelo

namespace MVC_Core.Controllers
{
    public class HistoryController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
