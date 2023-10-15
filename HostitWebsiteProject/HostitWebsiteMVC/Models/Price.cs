using System.Data.Odbc;

namespace HostitWebsiteMVC.Models
{
    public class Price
    {
        public Price(int id, string serviceName, string servicePrice, string rAM, string cloudStorage, string securityServices)
        {
            Id = id;
            ServiceName = serviceName;
            ServicePrice = servicePrice;
            RAM = rAM;
            CloudStorage = cloudStorage;
            SecurityServices = securityServices;
        }

        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string ServicePrice { get; set; }
        public string RAM { get; set; }
        public string CloudStorage { get; set; }
        public string SecurityServices { get; set; }

    }
}
