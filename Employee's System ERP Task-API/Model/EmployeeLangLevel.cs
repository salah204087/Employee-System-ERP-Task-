using EmployeeSystemERPTaskAPI.Model;

namespace EmployeeSystemERPTaskAPI.Model
{
    public class EmployeeLangLevel
    {
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public int LanguageLevelId { get; set; }
        public LanguageLevel? LanguageLevel { get; set; }
        public string? LanguageLevelName { get; set; }

    }
}
