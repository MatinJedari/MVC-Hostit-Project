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

        private readonly List<Price> _servicePrice = new List<Price>
        {
            new Price
            {
                ServiceName = "STARTUP",
                ServicePrice = "49",
                RAM = "2GB",
                CloudStorage = "20GB",
                SecurityServices = "DDoS Protection"
            },
            new Price
            {
                ServiceName = "STANDARD",
                ServicePrice = "99",
                RAM = "4GB",
                CloudStorage = "50GB",
                SecurityServices = "DDoS Protection"
            },
            new Price
            {
                ServiceName = "BUSINESS", 
                ServicePrice = "149",
                RAM = "8GB",
                CloudStorage = "100GB",
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
            return View(_servicePrice);
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
