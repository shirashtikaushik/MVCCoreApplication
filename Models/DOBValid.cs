using System.ComponentModel.DataAnnotations;

namespace MVCCoreApplication.Models
{
    public class DOBValid : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime? DOB = (DateTime)value;

                if (DOB != null)
                {
                    if (Convert.ToDateTime(DOB).Year >= 2002 && Convert.ToDateTime(DOB).Year <= 2005)
                    {
                        return ValidationResult.Success;
                    }

                }

            }

            return new ValidationResult(ErrorMessage ?? "Year must be between 2002 and 2005");
        }
    }
    }

