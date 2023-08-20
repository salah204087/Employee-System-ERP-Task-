using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeSystemERPTaskAPI.Model
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string? Name { get; set; }
        [Range(10000000000000, 99999999999999, ErrorMessage = "NationalId must be a 14-digit number.")]
        public long NationalId { get; set; }
        [Required]
        [Min18YearsOld]
        public DateTime? BirthDate { get; set; }
        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        public Language? Language { get; set; }
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public Account? Account { get; set; }
        [ForeignKey("BusinessLine")]
        public int BusinessLineId { get; set; }
        public LineOfBusiness? BusinessLine { get; set; }
        public List<EmployeeLangLevel>? EmployeeLangLevels { get; set; }

    }
}
