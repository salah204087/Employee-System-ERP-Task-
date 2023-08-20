using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskAPI.Model.DTO
{
    public class CreateLanguageLevelDTO
    {
        [Required]
        public string? Name { get; set; }
    }
}
