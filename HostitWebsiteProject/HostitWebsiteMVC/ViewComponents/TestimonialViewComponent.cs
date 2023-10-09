using HostitWebsiteMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HostitWebsiteMVC.ViewComponents
{
    public class TestimonialViewComponent : ViewComponent
    {
        private readonly List<Testimonial> _testimonials = new List<Testimonial>
        {
            new Testimonial("Morojink", "Customer", "Lorem ipsum dolor sit amet, consectetur " +
                "adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip " +
                "ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse " +
                "cillum dolore eu fugia "),
            new Testimonial("Morojink2", "Customer2", "Lorem ipsum dolor sit amet, consectetur " +
                "adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip " +
                "ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse " +
                "cillum dolore eu fugia "),
        };

        public IViewComponentResult Invoke()
        {
            return View("_Testimonial", _testimonials);
        }
    }
}
