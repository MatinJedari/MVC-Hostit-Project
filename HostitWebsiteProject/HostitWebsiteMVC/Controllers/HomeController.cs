using HostitWebsiteMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace HostitWebsiteMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly List<Price> _ServicePrice = new List<Price>
        {
            new Price
            {
                ServicePrice = "49",
                RAM = "2 GB",
                CloudStorage = "20 GB",
                SecurityServices = "DDoS Protection"
            },
            new Price
            {
                ServicePrice = "99",
                RAM = "4 GB",
                CloudStorage = "50 GB",
                SecurityServices = "DDoS Protection"
            },
            new Price
            {
                ServicePrice = "149",
                RAM = "8 GB",
                CloudStorage = "100 GB",
                SecurityServices = "DDoS Protection"
            }
        };
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pricing()
        {
            
            return View();
        }

        public IActionResult Contact()
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
