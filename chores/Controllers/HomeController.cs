using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using chores.Models;
using chores.Services;

namespace chores.Controllers
{
    public class HomeController : Controller
    {
        private readonly IChoreService choreService;
        public HomeController(IChoreService choreService)
        {
            this.choreService = choreService;
        }

        public IActionResult Index()
        {
            var model = choreService.GetChores().Select(c => c.Name);
            return View(model);
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
