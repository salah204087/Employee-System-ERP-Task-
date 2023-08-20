using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskWeb.Model.DTO
{
    public class CreateAccountDTO
    {
        [Required]
        public string? Name { get; set; }
        public List<int>? LineOfBusinessIds { get; set; }
        public List<string>? LineOfBusinesses { get; set; }

    }
}
