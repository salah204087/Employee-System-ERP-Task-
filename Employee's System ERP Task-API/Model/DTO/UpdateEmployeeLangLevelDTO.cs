using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskAPI.Model.DTO
{
    public class UpdateEmployeeLangLevelDTO
    {
        [Required]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        [Required]
        public int LanguageLevelId { get; set; }
        public LanguageLevel? LanguageLevel { get; set; }
        public string? LanguageLevelName { get; set; }

    }
}
