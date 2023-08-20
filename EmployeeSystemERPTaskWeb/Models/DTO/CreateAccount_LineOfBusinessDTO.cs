using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskWeb.Model.DTO
{
    public class CreateAccount_LineOfBusinessDTO
    {
        [Required]
        public int AccountId { get; set; }
        [Required]
        public int LineOfBusinessId { get; set; }
        public LineOfBusinessDTO? LineOfBusiness { get; set; }
        public string? LineOfBusinessName { get; set; }


    }
}
