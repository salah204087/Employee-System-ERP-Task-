using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EmployeeSystemERPTaskAPI.Model;

namespace EmployeeSystemERPTaskWeb.Model.DTO
{
    public class CreateEmployeeDTO:BaseEmployeeDTO
    {
        [Required]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string? Name { get; set; }
        [Range(10000000000000, 99999999999999, ErrorMessage = "NationalId must be a 14-digit number.")]
        public long NationalId { get; set; }
        [Required]
        public int LanguageId { get; set; }
        [Required]
        public int BusinessLineId { get; set; }
        public int AccountId { get; set; }
        public AccountDTO? Account { get; set; }
        public List<int>? LanguageLevelIds { get; set; }
    }
}
