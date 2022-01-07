/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OpenId.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

using Microsoft.AspNetCore.Mvc;
using Project.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Project.Models;
using System.Collections.Generic;
using System.Linq;

namespace Project.Controllers
{

    public class HomeController : Controller
    {

        private readonly ISteamService _SteamService;
        private readonly ISteamStoreService _SteamStoreService;

        public HomeController(ISteamService steamService, ISteamStoreService steamStoreService) 
        {
            _SteamService = steamService;
            _SteamStoreService = steamStoreService;
        }


        [HttpGet("~/")]
        public ActionResult Index() 
        {

            return View();
        }


        [HttpGet("~/Library")]
        public async Task<IActionResult> Library()
        {
            var NewGameCards = await GetGameCards();

            return View(NewGameCards);
        }

        public async Task<IEnumerable<GameCard>> GetGameCards() 
        {
            try
            {
                var GamesCollection = await _SteamService.GetGames("76561198209415171", "31B58AF8B951E085347B7DD4BB8B9A46");
                

              
                return GamesCollection;
            }
            catch (Exception ex)
            {

                Debug.Write(ex);
                return Enumerable.Empty<GameCard>();

            }
        }
    }
}
