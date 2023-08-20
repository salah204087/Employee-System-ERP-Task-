using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskAPI.Model.DTO
{
    public class CreateAccountDTO
    {
        [Required]
        public string? Name { get; set; }
        public List<int>? LineOfBusinessIds { get; set; }

    }
}
