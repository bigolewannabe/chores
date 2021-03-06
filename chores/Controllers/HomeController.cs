﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using chores.Models;
using chores.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace chores.Controllers
{
    public class HomeController : Controller
    {
        private readonly IChoreService choreService;
        private readonly ILogger logger;

        public HomeController(IChoreService choreService, ILogger<HomeController> logger)
        {
            this.choreService = choreService;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            var model = choreService.GetChores().First();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(Chore chore)
        {
            choreService.UpdateChores(chore);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
