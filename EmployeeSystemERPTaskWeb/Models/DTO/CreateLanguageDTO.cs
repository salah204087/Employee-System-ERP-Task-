using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskWeb.Model.DTO
{
    public class CreateLanguageDTO
    {
        [Required]
        public string? Name { get; set; }
    }
}
