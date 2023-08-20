﻿using EmployeeSystemERPTaskWeb.Model.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeSystemERPTaskWeb.Models.VM
{
    public class EmployeeCreateVM
    {
        public EmployeeCreateVM()
        {
            Employee=new CreateEmployeeDTO();
        }
        public CreateEmployeeDTO Employee { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> AccountList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> LanguageList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> LanguageLevelList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> LineOfBusinessList { get; set; }


    }
}
