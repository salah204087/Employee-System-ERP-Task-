using EmployeeSystemERPTaskAPI.Model.DTO;
using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskAPI.Model
{
    public class Min18YearsOld : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var baseEmployeeDTO = (BaseEmployeeDTO)validationContext.ObjectInstance;

            if (baseEmployeeDTO.BirthDate == null)
                return new ValidationResult("Birthdate is required.");

            var age = DateTime.Today.Year - baseEmployeeDTO.BirthDate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Employee should be at least 18 years.");
        }
    }
}
