using Microsoft.AspNetCore.Mvc;

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
