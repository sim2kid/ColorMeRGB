using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

// Written by Owen Ravelo

namespace MVC_Core.Controllers
{
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// The Auth Token stored in the user's Session
        /// </summary>
        public string AuthToken { 
            get 
            {
                if (HttpContext != null && HttpContext.Session.IsAvailable) 
                {
                    if (!HttpContext.Session.TryGetValue("AuthToken", out byte[]? data))
                    {
                        HttpContext.Session.SetString("AuthToken", string.Empty);
                    }
                    return HttpContext.Session.GetString("AuthToken") ?? string.Empty;
                }
                return string.Empty;
            }
            set 
            {
                if (HttpContext != null && HttpContext.Session.IsAvailable)
                {
                    HttpContext.Session.SetString("AuthToken", value);
                }
                else 
                {
                    if (HttpContext == null)
                    {
                        throw new NullReferenceException("HttpContext is null.");
                    }
                    else 
                    {
                        throw new Exception("HttpContext is inaccessible.");
                    }
                }
            }
        }

        /// <summary>
        /// Returns true if there is an Auth Token
        /// </summary>
        public bool isLoggedIn => !string.IsNullOrWhiteSpace(AuthToken);

        // Runs before each view
        public override void OnActionExecuting(ActionExecutingContext context) 
        {
            base.OnActionExecuting(context);

            // Sets a bool in the view bag if we're logged in or not
            ViewBag.LoggedIn = isLoggedIn;
        }
    }
}
