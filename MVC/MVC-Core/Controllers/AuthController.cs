using Microsoft.AspNetCore.Mvc;
using MVC_Core.Models;

// Written By Owen Ravelo

namespace MVC_Core.Controllers
{
    public class AuthController : BaseController
    {
        Services.AuthService auth = new Services.AuthService();

        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            // if has auth token
            if (!string.IsNullOrWhiteSpace(AuthToken)) 
            {
                // redirect to home screen
                return RedirectToAction("Index", "Home");
            }

            // Show login page
            return View(new AuthModel());
        }

        [HttpPost]
        [Route("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm]AuthModel model)
        {
            AuthToken = string.Empty;

            // On bad model
            if (!ModelState.IsValid)
            {
                // Bad Login
                ModelState.AddModelError("", "Invalid credentials.");

                model.Password = string.Empty;
                return View(model);
            }

            // Authenticate
            var response = await auth.Login(model.Username, model.Password);
            model.Password = string.Empty;
            if (!response.Authorized) 
            {
                // No API Access
                ModelState.AddModelError("", "Something went wrong...");

                return View(model);
            }
            if (!response.Success) 
            {
                // Bad credentials 
                ModelState.AddModelError("", "Invalid credentials.");

                return View(model);
            }

            // Set Valid Auth Token
            AuthToken = response.AuthToken;
            // Redirect to homepage
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout() 
        {
            AuthToken = string.Empty;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("SignUp")]
        public IActionResult SignUp()
        {
            // if has auth token
            if (!string.IsNullOrWhiteSpace(HttpContext.Session.GetString("AuthToken")))
            {
                // redirect to home screen
                return RedirectToAction("Index", "Home");
            }

            // Show signup pahe
            return View(new AuthModel());
        }

        [HttpPost]
        [Route("SignUp")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp([FromForm] AuthModel model)
        {
            AuthToken = string.Empty;

            // On bad model
            if (!ModelState.IsValid)
            {
                // Bad Signup
                model.Password = string.Empty;
                return View(model);
            }

            // Attempt To Register
            var response = await auth.Signup(model.Username, model.Password);
            model.Password = string.Empty;
            if (!response.Authorized)
            {
                // No API Access
                ModelState.AddModelError("", "Something went wrong...");

                return View(model);
            }
            if (!response.Success)
            {
                // Username not avaliable 
                ModelState.AddModelError("", "Username is taken.");

                return View(model);
            }

            // Set Valid Auth Token
            AuthToken = response.AuthToken;
            // Redirect to homepage
            return RedirectToAction("Index", "Home");
        }
    }
}
