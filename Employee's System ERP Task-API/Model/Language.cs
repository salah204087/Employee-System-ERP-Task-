using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskAPI.Model
{
    public class Language
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
