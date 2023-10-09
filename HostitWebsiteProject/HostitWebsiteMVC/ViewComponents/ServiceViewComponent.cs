using HostitWebsiteMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HostitWebsiteMVC.ViewComponents
{
    public class ServiceViewComponent : ViewComponent
    {
        private readonly List<Service> _services = new List<Service>
        {
            new Service("Shared Hosting",
                "Generators on the Internet tend to repeat predefined chunks as necessary", 
                "s1.png"),
            new Service("Dedicated Hosting",
                "Generators on the Internet tend to repeat predefined chunks as necessary",
                "s2.png"),
            new Service("Cloud Hosting",
                "Generators on the Internet tend to repeat predefined chunks as necessary",
                "s3.png"),
            new Service("VPS Hosting",
                "Generators on the Internet tend to repeat predefined chunks as necessary",
                "s4.png"),
            new Service("Wordpress Hosting",
                "Generators on the Internet tend to repeat predefined chunks as necessary",
                "s5.png"),
            new Service("Domain Name",
                "Generators on the Internet tend to repeat predefined chunks as necessary",
                "s6.png"),
        };

        public IViewComponentResult Invoke()
        {
            return View("_Services", _services);
        }
    }
}
