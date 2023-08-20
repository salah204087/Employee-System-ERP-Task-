using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskWeb.Model.DTO
{
    public class CreateEmployeeLangLevelDTO
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int LanguageLevelId { get; set; }
        public string? LanguageLevelName { get; set; }


    }
}
