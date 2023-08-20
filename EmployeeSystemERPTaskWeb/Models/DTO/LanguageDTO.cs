using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskWeb.Model.DTO
{
    public class LanguageDTO
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
