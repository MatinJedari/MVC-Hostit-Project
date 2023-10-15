using HostitWebsiteMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HostitWebsiteMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly List<Price> _servicePrice = new List<Price>
        {
            new Price(1, "STARTUP", "49", "2GB", "20GB", "DDoS Protection"),
            new Price(2, "STANDARD", "99", "4GB", "50GB", "DDoS Protection"),
            new Price(3, "BUSINESS", "149", "8GB", "100GB", "DDoS Protection")
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

        [HttpGet]
        public IActionResult Contact()
        {
            var model = new ContactMessage
            {
                ServicePrice = new SelectList(_servicePrice, "Id", "ServiceName")
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Contact(ContactMessage form)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.error = "My apologies, an issue has occurred. Please try again.";
                return View(form);
            }

            string jsonFilePath = Directory.GetCurrentDirectory() + "/DataRepository/ContactMessageData.json";
            List<ContactMessage> contactMessages = new List<ContactMessage>();
            if (System.IO.File.Exists(jsonFilePath))
            {
                string json = System.IO.File.ReadAllText(jsonFilePath);
                contactMessages = JsonConvert.DeserializeObject<List<ContactMessage>>(json);
            }

            contactMessages.Add(form);

            string updatedJson = JsonConvert.SerializeObject(contactMessages);
            System.IO.File.WriteAllText(jsonFilePath, updatedJson);

            ViewBag.success = "Your message has been successfully sent. We appreciate your kind attention.";
            return View();

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
