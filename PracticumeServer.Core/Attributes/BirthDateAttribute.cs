using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumeServer.Core.Validators
{
    public class BirthDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime birthDate = (DateTime)value;
                if (birthDate >= DateTime.Today)
                {
                    return new ValidationResult("BirthDate must be before today");
                }
            }

            return ValidationResult.Success;
        }
    }
}
