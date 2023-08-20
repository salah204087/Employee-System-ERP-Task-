using EmployeeSystemERPTaskWeb.Model.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeSystemERPTaskWeb.Models.VM
{
    public class AccountCreateVM
    {
        public AccountCreateVM()
        {
            Account = new CreateAccountDTO();
        }
        public CreateAccountDTO Account { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> LineOfBusinessList { get; set; }
    }
}
