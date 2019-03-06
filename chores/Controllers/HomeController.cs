using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using chores.Models;

namespace chores.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new List<string>{ "Put on PJ's", "Dirty laundry in laundry basket", "Teeth brushed"};
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
