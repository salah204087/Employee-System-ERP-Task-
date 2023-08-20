using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskWeb.Model.DTO
{
    public class UpdateEmployeeLangLevelDTO
    {
        [Required]
        public int EmployeeId { get; set; }
        public EmployeeDTO? Employee { get; set; }
        [Required]
        public int LanguageLevelId { get; set; }
        public LanguageLevelDTO? LanguageLevel { get; set; }
        public string? LanguageLevelName { get; set; }

    }
}
