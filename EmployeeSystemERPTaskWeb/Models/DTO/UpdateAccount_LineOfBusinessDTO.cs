using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskWeb.Model.DTO
{
    public class UpdateAccount_LineOfBusinessDTO
    {
        [Required]
        public int AccountId { get; set; }
        public AccountDTO? Account { get; set; }
        [Required]
        public int LineOfBusinessId { get; set; }
        public LineOfBusinessDTO? LineOfBusiness { get; set; }
        public string? LineOfBusinessName { get; set; }

    }
}
