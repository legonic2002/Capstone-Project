using System.ComponentModel.DataAnnotations;

namespace RAFS.Web.Validation
{
    public class AllowEmptyEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                // Empty or null value, considered valid
                return ValidationResult.Success;
            }

            // Check if the value matches the email format
            var emailAddressAttribute = new EmailAddressAttribute();
            if (!emailAddressAttribute.IsValid(value))
            {
                // Not a valid email format
                return new ValidationResult("Địa chỉ email không hợp lệ");
            }

            // Value is a valid email
            return ValidationResult.Success;
        }
    }
}
