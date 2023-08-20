using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskAPI.Model.DTO
{
    public class LineOfBusinessCreateDTO
    {
        [Required]
        public string? Name { get; set; }
    }
}
