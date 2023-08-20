using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskAPI.Model.DTO
{
    public class CreateLangLevelDTO
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int LanguageLevelId { get; set; }
    }
}
