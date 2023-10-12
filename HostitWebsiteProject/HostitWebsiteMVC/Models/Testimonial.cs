using System.Reflection.Metadata.Ecma335;

namespace HostitWebsiteMVC.Models
{
    public class Testimonial
    {
        public string CustomerName { get; set; }
        public string CustomerJob { get; set; }
        public string CustomerSight { get; set; }

        public Testimonial(string customerName, string customerJob, string customerSight)
        {
            CustomerName = customerName;
            CustomerJob = customerJob;
            CustomerSight = customerSight;
        }
    }
}
