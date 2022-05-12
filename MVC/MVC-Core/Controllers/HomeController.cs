using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Written by Owen Ravelo

namespace MVC_Core.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [Route("privacy")]
        public ActionResult Privacy()
        {
            return View();
        }

        [Route("credits")]
        public ActionResult Credits()
        {
            return View();
        }

        [Route("how-to-play")]
        public ActionResult Instructions()
        {
            return View();
        }
        [Route("cookies")]
        public ActionResult Cookies()
        {
            return View();
        }
    }
}