using System;
using System.ComponentModel.DataAnnotations;

namespace Klooz3.Validation
{
    public class StartsWithHttp : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string url = value.ToString();

                if (!url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                {
                    // Prepend "https://" to the URL
                    url = "https://" + url;

                    // Set the modified value back to the property
                    validationContext.ObjectType.GetProperty(validationContext.MemberName)?.SetValue(validationContext.ObjectInstance, url);
                }
            }

            return ValidationResult.Success;
        }
    }
}
