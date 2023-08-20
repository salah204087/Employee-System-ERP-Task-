using AutoMapper;
using EmployeeSystemERPTaskUtility;
using EmployeeSystemERPTaskWeb.Model.DTO;
using EmployeeSystemERPTaskWeb.Models;
using EmployeeSystemERPTaskWeb.Models.VM;
using EmployeeSystemERPTaskWeb.Services;
using EmployeeSystemERPTaskWeb.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Data;

namespace EmployeeSystemERPTaskWeb.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILanguageLevelService _languageLevelService;
        private readonly ILanguageService _languageService;
        private readonly IAccountService _accountService;
        private readonly ILineOfBusinessService _lineOfBusinessService;
        private readonly IAccountLineOfBusinessService _accountLineOfBusinessService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper, ILanguageLevelService languageLevelService, ILanguageService languageService, IAccountService accountService, IAccountLineOfBusinessService accountLineOfBusinessService, ILineOfBusinessService lineOfBusinessService)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _languageLevelService = languageLevelService;
            _languageService = languageService;
            _accountService = accountService;
            _accountLineOfBusinessService = accountLineOfBusinessService;
            _lineOfBusinessService = lineOfBusinessService;
        }
        public async Task<IActionResult> Index()
        {
            List<EmployeeDTO> list = new();
            var response = await _employeeService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
                list = JsonConvert.DeserializeObject<List<EmployeeDTO>>(Convert.ToString(response.Result));
            return View(list);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create()
        {
            EmployeeCreateVM employeeCreateVM = new();
            var languageLevelResponse = await _languageLevelService
                .GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (languageLevelResponse != null && languageLevelResponse.IsSuccess)
            {
                employeeCreateVM.LanguageLevelList = JsonConvert
                    .DeserializeObject<List<LanguageLevelDTO>>(Convert.ToString(languageLevelResponse.Result))
                    .Select(n => new SelectListItem
                    {
                        Text = n.Name,
                        Value = n.Id.ToString(),
                    });
            }
            var languageResponse = await _languageService
               .GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (languageResponse != null && languageResponse.IsSuccess)
            {
                employeeCreateVM.LanguageList = JsonConvert
                    .DeserializeObject<List<LanguageDTO>>(Convert.ToString(languageResponse.Result))
                    .Select(n => new SelectListItem
                    {
                        Text = n.Name,
                        Value = n.Id.ToString(),
                    });
            }
            var accountResponse = await _accountService
               .GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (accountResponse != null && accountResponse.IsSuccess)
            {
                employeeCreateVM.AccountList = JsonConvert
                    .DeserializeObject<List<AccountDTO>>(Convert.ToString(accountResponse.Result))
                    .Select(n => new SelectListItem
                    {
                        Text = n.Name,
                        Value = n.Id.ToString(),
                    });
            }
            var lineOfBusinessResponse = await _lineOfBusinessService
              .GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (lineOfBusinessResponse != null && lineOfBusinessResponse.IsSuccess)
            {
                employeeCreateVM.LineOfBusinessList = JsonConvert
                    .DeserializeObject<List<LineOfBusinessDTO>>(Convert.ToString(lineOfBusinessResponse.Result))
                    .Select(n => new SelectListItem
                    {
                        Text = n.Name,
                        Value = n.Id.ToString(),
                    });
            }


            return View(employeeCreateVM);
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeCreateVM employeeCreateVM)
        {
            if (ModelState.IsValid)
            { 
                var response = await _employeeService
                    .CreateAsync<APIResponse>(employeeCreateVM.Employee, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Employee Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("Error Messages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }
            var languageLevelResponse = await _languageLevelService
                .GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (languageLevelResponse != null && languageLevelResponse.IsSuccess)
            {
                employeeCreateVM.LanguageLevelList = JsonConvert
                    .DeserializeObject<List<LineOfBusinessDTO>>(Convert.ToString(languageLevelResponse.Result))
                    .Select(n => new SelectListItem
                    {
                        Text = n.Name,
                        Value = n.Id.ToString(),
                    });
            }
            var languageResponse = await _languageService
               .GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (languageResponse != null && languageResponse.IsSuccess)
            {
                employeeCreateVM.LanguageList = JsonConvert
                    .DeserializeObject<List<LanguageDTO>>(Convert.ToString(languageResponse.Result))
                    .Select(n => new SelectListItem
                    {
                        Text = n.Name,
                        Value = n.Id.ToString(),
                    });
            }
            var accountResponse = await _accountService
               .GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (accountResponse != null && accountResponse.IsSuccess)
            {
                employeeCreateVM.AccountList = JsonConvert
                    .DeserializeObject<List<AccountDTO>>(Convert.ToString(accountResponse.Result))
                    .Select(n => new SelectListItem
                    {
                        Text = n.Name,
                        Value = n.Id.ToString(),
                    });
            }
            var lineOfBusinessResponse = await _lineOfBusinessService
             .GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (lineOfBusinessResponse != null && lineOfBusinessResponse.IsSuccess)
            {
                employeeCreateVM.LineOfBusinessList = JsonConvert
                    .DeserializeObject<List<LineOfBusinessDTO>>(Convert.ToString(lineOfBusinessResponse.Result))
                    .Select(n => new SelectListItem
                    {
                        Text = n.Name,
                        Value = n.Id.ToString(),
                    });
            }

            TempData["error"] = "Error Encountered.";
            return View(employeeCreateVM);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update(int id)
        {
            EmployeeUpdateVM employeeUpdateVM = new();
            var response = await _employeeService.GetAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                EmployeeDTO model = JsonConvert.DeserializeObject<EmployeeDTO>(Convert.ToString(response.Result));
                employeeUpdateVM.Employee = _mapper.Map<UpdateEmployeeDTO>(model);
                var languageLevelResponse = await _languageLevelService
                .GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
                if (languageLevelResponse != null && languageLevelResponse.IsSuccess)
                {
                    employeeUpdateVM.LanguageLevelList = JsonConvert
                        .DeserializeObject<List<LineOfBusinessDTO>>(Convert.ToString(languageLevelResponse.Result))
                        .Select(n => new SelectListItem
                        {
                            Text = n.Name,
                            Value = n.Id.ToString(),
                        });
                }
                var languageResponse = await _languageService
                   .GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
                if (languageResponse != null && languageResponse.IsSuccess)
                {
                    employeeUpdateVM.LanguageList = JsonConvert
                        .DeserializeObject<List<LanguageDTO>>(Convert.ToString(languageResponse.Result))
                        .Select(n => new SelectListItem
                        {
                            Text = n.Name,
                            Value = n.Id.ToString(),
                        });
                }
                var accountResponse = await _accountService
                   .GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
                if (accountResponse != null && accountResponse.IsSuccess)
                {
                    employeeUpdateVM.AccountList = JsonConvert
                        .DeserializeObject<List<AccountDTO>>(Convert.ToString(accountResponse.Result))
                        .Select(n => new SelectListItem
                        {
                            Text = n.Name,
                            Value = n.Id.ToString(),
                        });
                }
                var lineOfBusinessResponse = await _lineOfBusinessService
                        .GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
                if (lineOfBusinessResponse != null && lineOfBusinessResponse.IsSuccess)
                {
                    employeeUpdateVM.LineOfBusinessList = JsonConvert
                        .DeserializeObject<List<LineOfBusinessDTO>>(Convert.ToString(lineOfBusinessResponse.Result))
                        .Select(n => new SelectListItem
                        {
                            Text = n.Name,
                            Value = n.Id.ToString(),
                        });
                }

                return View(employeeUpdateVM);
            }
            return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(EmployeeUpdateVM employeeUpdateVM)
        {
            if (ModelState.IsValid)
            {
                var response = await _employeeService.UpdateAsync<APIResponse>(employeeUpdateVM.Employee, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Employee Updated Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }

            var languageLevelResponse = await _languageLevelService
                  .GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (languageLevelResponse != null && languageLevelResponse.IsSuccess)
            {
                employeeUpdateVM.LanguageLevelList = JsonConvert
                    .DeserializeObject<List<LineOfBusinessDTO>>(Convert.ToString(languageLevelResponse.Result))
                    .Select(n => new SelectListItem
                    {
                        Text = n.Name,
                        Value = n.Id.ToString(),
                    });
            }
            var languageResponse = await _languageService
               .GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (languageResponse != null && languageResponse.IsSuccess)
            {
                employeeUpdateVM.LanguageList = JsonConvert
                    .DeserializeObject<List<LanguageDTO>>(Convert.ToString(languageResponse.Result))
                    .Select(n => new SelectListItem
                    {
                        Text = n.Name,
                        Value = n.Id.ToString(),
                    });
            }
            var accountResponse = await _accountService
               .GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (accountResponse != null && accountResponse.IsSuccess)
            {
                employeeUpdateVM.AccountList = JsonConvert
                    .DeserializeObject<List<AccountDTO>>(Convert.ToString(accountResponse.Result))
                    .Select(n => new SelectListItem
                    {
                        Text = n.Name,
                        Value = n.Id.ToString(),
                    });
            }
            var lineOfBusinessResponse = await _lineOfBusinessService
            .GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (lineOfBusinessResponse != null && lineOfBusinessResponse.IsSuccess)
            {
                employeeUpdateVM.LineOfBusinessList = JsonConvert
                    .DeserializeObject<List<LineOfBusinessDTO>>(Convert.ToString(lineOfBusinessResponse.Result))
                    .Select(n => new SelectListItem
                    {
                        Text = n.Name,
                        Value = n.Id.ToString(),
                    });
            }

            TempData["error"] = "Error Encountered.";
            return View(employeeUpdateVM);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            EmployeeDeleteVM employeeDeleteVM = new();
            var response = await _employeeService.GetAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                EmployeeDTO model = JsonConvert.DeserializeObject<EmployeeDTO>(Convert.ToString(response.Result));
                employeeDeleteVM.Employee = model;
                var languageLevelResponse = await _languageLevelService
                  .GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
                if (languageLevelResponse != null && languageLevelResponse.IsSuccess)
                {
                    employeeDeleteVM.LanguageLevelList = JsonConvert
                        .DeserializeObject<List<LineOfBusinessDTO>>(Convert.ToString(languageLevelResponse.Result))
                        .Select(n => new SelectListItem
                        {
                            Text = n.Name,
                            Value = n.Id.ToString(),
                        });
                }
                var languageResponse = await _languageService
                   .GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
                if (languageResponse != null && languageResponse.IsSuccess)
                {
                    employeeDeleteVM.LanguageList = JsonConvert
                        .DeserializeObject<List<LanguageDTO>>(Convert.ToString(languageResponse.Result))
                        .Select(n => new SelectListItem
                        {
                            Text = n.Name,
                            Value = n.Id.ToString(),
                        });
                }
                var accountResponse = await _accountService
                   .GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
                if (accountResponse != null && accountResponse.IsSuccess)
                {
                    employeeDeleteVM.AccountList = JsonConvert
                        .DeserializeObject<List<AccountDTO>>(Convert.ToString(accountResponse.Result))
                        .Select(n => new SelectListItem
                        {
                            Text = n.Name,
                            Value = n.Id.ToString(),
                        });
                }
                var lineOfBusinessResponse = await _lineOfBusinessService
            .GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
                if (lineOfBusinessResponse != null && lineOfBusinessResponse.IsSuccess)
                {
                    employeeDeleteVM.LineOfBusinessList = JsonConvert
                        .DeserializeObject<List<LineOfBusinessDTO>>(Convert.ToString(lineOfBusinessResponse.Result))
                        .Select(n => new SelectListItem
                        {
                            Text = n.Name,
                            Value = n.Id.ToString(),
                        });
                }
                return View(employeeDeleteVM);
            }
            return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(EmployeeDeleteVM employeeDeleteVM)
        {
            var response = await _employeeService
                .DeleteAsync<APIResponse>(employeeDeleteVM.Employee.Id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Employee Deleted Successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error Encountered.";
            return View(employeeDeleteVM);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DownloadEmployeesExcel()
        {
            var employees = await _employeeService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (employees != null && employees.IsSuccess)
            {
                List<EmployeeDTO> employeeList = JsonConvert.DeserializeObject<List<EmployeeDTO>>(Convert.ToString(employees.Result));

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Employees");

                    // Headers
                    var headers = new string[]
                    {
                     "Name", "National Id", "Date of Birth", "Language", "Language Level", "Account","Business Line"
                    };

                    for (int i = 0; i < headers.Length; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = headers[i];
                        worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                        worksheet.Cells[1, i + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    }

                    // Data rows
                    for (int i = 0; i < employeeList.Count; i++)
                    {
                        var employee = employeeList[i];
                        var langLevelsNames = employee.EmployeeLangLevels.Select(langLevel => langLevel.LanguageLevelName);
                        var joinedNames = string.Join(", ", langLevelsNames);
                        worksheet.Cells[i + 2, 1].Value = employee.Name;
                        worksheet.Cells[i + 2, 2].Value = employee.NationalId;
                        worksheet.Cells[i + 2, 3].Value = employee.BirthDate;
                        worksheet.Cells[i + 2, 3].Style.Numberformat.Format = "yyyy-mm-dd";
                        worksheet.Cells[i + 2, 4].Value = employee.Language.Name;
                        worksheet.Cells[i + 2, 5].Value = joinedNames;
                        worksheet.Cells[i + 2, 6].Value = employee.Account.Name;
                        worksheet.Cells[i + 2, 7].Value = employee.BusinessLine.Name;
                       
                    }

                    worksheet.Cells.AutoFitColumns();

                    var excelData = package.GetAsByteArray();

                    return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Employees.xlsx");
                }
            }

            TempData["error"] = "Error Encountered.";
            return RedirectToAction("Index");
        }
     

    }

}

