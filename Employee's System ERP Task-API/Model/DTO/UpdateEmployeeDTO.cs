using EmployeeSystemERPTaskAPI.Model.DTO;
using EmployeeSystemERPTaskAPI.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskAPI.Model.DTO
{
    public class UpdateEmployeeDTO:BaseEmployeeDTO
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Only alphabetic characters are allowed.")]

        public string? Name { get; set; }
        [Range(10000000000000, 99999999999999, ErrorMessage = "NationalId must be a 14-digit number.")]
        [Required]
        public int BusinessLineId { get; set; }
        public long NationalId { get; set; }
        [Required]
        public int LanguageId { get; set; }
        public int AccountId { get; set; }
        public AccountDTO? Account { get; set; }
        public List<int>? LanguageLevelIds { get; set; }
    }
}
