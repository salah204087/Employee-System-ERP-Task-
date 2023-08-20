using EmployeeSystemERPTaskAPI.Model;
using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskAPI.Model.DTO
{
    public class UpdateAccount_LineOfBusinessDTO
    {
        [Required]
        public int AccountId { get; set; }
        public Account? Account { get; set; }
        [Required]
        public int LineOfBusinessId { get; set; }
        public LineOfBusiness? LineOfBusiness { get; set; }
        public string? LineOfBusinessName { get; set; }

    }
}
