using System;
using System.ComponentModel.DataAnnotations;

namespace HostitWebsiteMVC.Validations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class EnsureOptionIsSelectedAttribute : ValidationAttribute
    {
        public EnsureOptionIsSelectedAttribute()
        {
            ErrorMessage = "Please select an option other than the default."; // Set your custom error message here

        }

        public override bool IsValid(object value)
        {
            // The value is the SelectedOptionId
            int selectedOptionId = Convert.ToInt32(value);

            // Check if the selected option is the default (ID equal to zero)
            return selectedOptionId != 0;
        }
    }
}
