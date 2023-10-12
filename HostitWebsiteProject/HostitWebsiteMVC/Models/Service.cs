﻿namespace HostitWebsiteMVC.Models
{
    public class Service
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image {  get; set; }

        public Service(string name, string description, string image)
        {
            Name = name;
            Description = description;
            Image = image;
        }
    }
}
