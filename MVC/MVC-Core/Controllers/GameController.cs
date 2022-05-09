using Microsoft.AspNetCore.Mvc;
using MVC_Core.Models;
using Services;
using Services.Color_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Written by Owen Ravelo

namespace MVC_Core.Controllers
{
    public class GameController : BaseController
    {
        GameService game = new GameService();

        public GameModel? gameModel
        {
            get
            {
                if (HttpContext != null && HttpContext.Session.IsAvailable)
                {
                    if (!HttpContext.Session.TryGetValue("GameModel", out byte[]? data))
                    {
                        HttpContext.Session.SetString("GameModel", new GameModel().toJson());
                    }
                    return GameModel.FromJson(HttpContext.Session.GetString("GameModel")) ?? null;
                }
                return null;
            }
            set
            {
                if (HttpContext != null && HttpContext.Session.IsAvailable)
                {
                    if (value == null)
                    {
                        HttpContext.Session.SetString("GameModel", string.Empty);
                    }
                    else
                    {
                        HttpContext.Session.SetString("GameModel", value.toJson());
                    }
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


        [HttpGet]
        public async Task<ActionResult> Index()
        {
            // Check if logged in
            if (!isLoggedIn) 
            {
                return RedirectToAction("Login", "Auth");
            }

            GameFormModel model = new GameFormModel();
            // Request new game
            var newGameResponse = await game.NewGame(AuthToken);
            if (!newGameResponse.Authorized) 
            {
                // API Error
                ModelState.AddModelError("", "An unknown error has occured...");
                Logger.Logger.Instance.Warning("API is not accessible from MVC");
                return View(model);
            }
            if (!newGameResponse.Authenticated) 
            {
                // Login expired or not logged in
                return RedirectToAction("Login", "Auth");
            }
            if (!newGameResponse.Success) 
            {
                // Some unknown problem has occured
                ModelState.AddModelError("", "An unknown error has occured...");
                return View(model);
            }
            // We can now make a game!
            var gm = new GameModel(newGameResponse.GameId.Value, new RGBModel(game.GetGameColor()));

            var response = await game.Start(AuthToken, gm.Id, gm.Answer);
            if (!response.Authorized)
            {
                // API Error
                ModelState.AddModelError("", "An unknown error has occured...");
                Logger.Logger.Instance.Warning("API is not accessible from MVC");
                return View(model);
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
                return View(model);
            }

            // Start the game
            gameModel = gm;
            ViewBag.Game = gm;
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Index([FromForm] GameFormModel model)
        {
            // Check if logged in
            if (!isLoggedIn)
            {
                return RedirectToAction("Login", "Auth");
            }

            var gm = gameModel;

            // Make sure incoming model is valid
            if (!ModelState.IsValid || gm == null) 
            {
                ModelState.AddModelError("", "Answer not recorded due to errors.");
                return View(model);
            }

            // Plot new bits to database
            var response = await game.MakeGuess(AuthToken, gm.Id, gm.Answer, model.Response, gm.Guesses.Count);
            if (!response.Authorized)
            {
                // API Error
                ModelState.AddModelError("", "An unknown error has occured...");
                Logger.Logger.Instance.Warning("API is not accessible from MVC");
                return View(model);
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
                return View(model);
            }

            // Redirect on Win
            bool end = game.hasWin(gm.Answer, model.Response) || game.hasEnd(gm.Guesses.Count);
            if (end) 
            {
                gm = null;
                return RedirectToAction("Index", "History");
            }

            var color = new RGBModel(model.Response);
            // Populate model for future use
            gm.AddGuess(new GuessModel() { Color = color, Distance = RGBModel.Distance(color, gm.Answer)});

            gameModel = gm;
            ViewBag.Game = gm;
            return View(model);
        }
    }
}
