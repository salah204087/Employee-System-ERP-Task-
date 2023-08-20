using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskWeb.Model.DTO
{
    public class CreateLangLevelDTO
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int LanguageLevelId { get; set; }
    }
}
