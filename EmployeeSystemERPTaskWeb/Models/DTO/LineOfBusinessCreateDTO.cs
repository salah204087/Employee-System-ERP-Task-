using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskWeb.Model.DTO
{
    public class LineOfBusinessCreateDTO
    {
        [Required]
        public string? Name { get; set; }
    }
}
