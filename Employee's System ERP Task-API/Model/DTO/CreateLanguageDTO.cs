using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskAPI.Model.DTO
{
    public class CreateLanguageDTO
    {
        [Required]
        public string? Name { get; set; }
    }
}
