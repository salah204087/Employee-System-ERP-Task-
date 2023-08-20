using EmployeeSystemERPTaskWeb.Model.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeSystemERPTaskWeb.Models.VM
{
    public class AccountVM
    {
        public AccountVM()
        {
            Account = new AccountDTO();
        }
        public AccountDTO Account { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> LineOfBusinessList { get; set; }
    }
}
