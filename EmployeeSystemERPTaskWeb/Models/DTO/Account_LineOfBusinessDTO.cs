using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskWeb.Model.DTO
{
    public class Account_LineOfBusinessDTO
    {
        public int LineOfBusinessId { get; set; }
        public LineOfBusinessDTO? LineOfBusiness { get; set; }
        public int AccountId { get; set; }
        public string? LineOfBusinessName { get; set; }


    }
}
