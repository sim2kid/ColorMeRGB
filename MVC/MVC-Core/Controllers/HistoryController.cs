using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Models;

// Written by Owen Ravelo

namespace MVC_Core.Controllers
{
    public class HistoryController : BaseController
    {
        HistoryService past = new HistoryService();

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Check if logged in
            if (!isLoggedIn)
            {
                return RedirectToAction("Login", "Auth");
            }

            List<GameModel> Games = new List<GameModel>();
            var response = await past.GetPastGames(AuthToken);
            if (!response.Authorized)
            {
                // API Error
                ModelState.AddModelError("", "An unknown error has occured...");
                return View(Games);
            }
            if (!response.Authenticated)
            {
                // Login expired or not logged in
                return RedirectToAction("Login", "Auth");
            }
            if (!response.Success)
            {
                // Some unknown problem has occured
                ModelState.AddModelError("", "An unknown error has occured...");
                return View(Games);
            }

            Games = response.Games;
            return View(Games);
        }
    }
}
