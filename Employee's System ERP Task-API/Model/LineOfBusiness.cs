using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskAPI.Model
{
    public class LineOfBusiness
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public List<Account_LineOfBusiness>? Account_LineOfBusiness { get; set; }

    }
}
