using HostitWebsiteMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HostitWebsiteMVC.ViewComponents
{
    public class TestimonialViewComponent : ViewComponent
    {
        private readonly List<Testimonial> _testimonials = new List<Testimonial>
        {
            new Testimonial("Morojink", "Customer", "lab lab lab ..."),
            new Testimonial("Morojink2", "Customer2", "lab lab lab ..."),
        };

        public IViewComponentResult Invoke()
        {
            return View("_Testimonial", _testimonials);
        }
    }
}
