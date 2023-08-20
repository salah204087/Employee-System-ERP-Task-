using EmployeeSystemERPTaskAPI.Model;
using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskAPI.Model.DTO
{
    public class Account_LineOfBusinessDTO
    {
        public int AccountId { get; set; }
        //public Account? Account { get; set; }
        public int LineOfBusinessId { get; set; }
        public LineOfBusiness? LineOfBusiness { get; set; }
        public string? LineOfBusinessName { get; set; }


    }
}
