using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskWeb.Model.DTO
{
    public class CreateLanguageLevelDTO
    {
        [Required]
        public string? Name { get; set; }
    }
}
