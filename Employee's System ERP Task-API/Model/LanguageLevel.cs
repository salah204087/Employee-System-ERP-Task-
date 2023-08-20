using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskAPI.Model
{
    public class LanguageLevel
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public List<EmployeeLangLevel>? EmployeeLangLevels { get; set; }

    }
}
