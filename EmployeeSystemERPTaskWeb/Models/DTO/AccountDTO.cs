using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskWeb.Model.DTO
{
    public class AccountDTO
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public List<int>? LineOfBusinessIds { get; set; }
        public List<Account_LineOfBusinessDTO>? Account_LineOfBusiness { get; set; }


    }
}
