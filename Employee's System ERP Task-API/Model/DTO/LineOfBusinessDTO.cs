using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskAPI.Model.DTO
{
    public class LineOfBusinessDTO
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
