using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskWeb.Model.DTO
{
    public class EmployeeDTO:BaseEmployeeDTO
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string? Name { get; set; }
        [Range(10000000000000, 99999999999999, ErrorMessage = "NationalId must be a 14-digit number.")]
        public long NationalId { get; set; }

        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        public LanguageDTO? Language { get; set; }
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public AccountDTO? Account { get; set; }
        [ForeignKey("BusinessLine")]
        public int BusinessLineId { get; set; }
        public LineOfBusinessDTO? BusinessLine { get; set; }
        public List<EmployeeLangLevelDTO>? EmployeeLangLevels { get; set; }

    }
}
