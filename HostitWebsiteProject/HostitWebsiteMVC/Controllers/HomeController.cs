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
            // Creating services and their related information
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
            /* -----------------------------------------------------
              We need to send our model to the view for model binding.
            Therefore, we create an instance of the 'Contact' model
            and send it to the view.
            ----------------------------------------------------- */
            var model = new ContactMessage
            {
                /* ------------------------------------------------------------
                  ServicePrice' is one of the model's properties. Therefore, 
                to create an instance of the model and send it to the view,
                all properties must be specified.

                  The required information for creating the select list is 
                available within (_servicePrice). So, we send this variable 
                to the class constructor.
                ------------------------------------------------------------ */
                ServicePrice = new SelectList(_servicePrice, "Id", "ServiceName")
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Contact(ContactMessage model)
        {
            // Assigning a value to the 'ServicePrice' property
            model.ServicePrice = new SelectList(_servicePrice, "Id", "ServiceName");


            if (!ModelState.IsValid)
            {
                ViewBag.error = "My apologies, an issue has occurred. Please try again.";
                return View(model);
            }

            // In this section, we want to save the information entered through the Contact Us form in a JSON file.
            string jsonFilePath = Directory.GetCurrentDirectory() + "/DataRepository/ContactMessageData.json";
            List<ContactMessage> contactMessages = new List<ContactMessage>();

            if (System.IO.File.Exists(jsonFilePath))
            {
                string json = System.IO.File.ReadAllText(jsonFilePath);
                contactMessages = JsonConvert.DeserializeObject<List<ContactMessage>>(json);
            }

            contactMessages.Add(model);

            string updatedJson = JsonConvert.SerializeObject(contactMessages);
            System.IO.File.WriteAllText(jsonFilePath, updatedJson);

            ViewBag.success = "Your message has been successfully sent. We appreciate your kind attention.";


            ModelState.Clear();

            model = new ContactMessage
            {
                ServicePrice = new SelectList(_servicePrice, "Id", "ServiceName")
            };

            return View(model);

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
