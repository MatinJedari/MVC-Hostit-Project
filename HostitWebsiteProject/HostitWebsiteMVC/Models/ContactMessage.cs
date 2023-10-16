using HostitWebsiteMVC.Validations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HostitWebsiteMVC.Models
{
    public class ContactMessage
    {
        [Required(ErrorMessage = "Entering the name is mandatory")]
        [MinLength(2, ErrorMessage = "The minimum length of the name must be 2 characters.")]
        [MaxLength(100, ErrorMessage = "The maximum length of the name must be 100 characters")]
        // [JsonProperty("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Entering the email is mandatory")]
        [EmailAddress(ErrorMessage = "Please enter a valid Email address")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Please enter a valid Email address")]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required(ErrorMessage = "Message content is required.")]
        [StringLength(800, MinimumLength = 10, ErrorMessage = "Message must be between 10 and 800 characters.")]
        public string Message { get; set; }

        public int Service { get; set; }

        public SelectList ServicePrice { get; set; }
    }
}
