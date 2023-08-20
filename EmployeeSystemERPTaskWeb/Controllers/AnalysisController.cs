using Azure;
using EmployeeSystemERPTaskUtility;
using EmployeeSystemERPTaskWeb.Model.DTO;
using EmployeeSystemERPTaskWeb.Models;
using EmployeeSystemERPTaskWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeSystemERPTaskWeb.Controllers
{
    public class AnalysisController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILanguageService _languageService;
        private readonly IAccountService _accountService;
        public AnalysisController(IEmployeeService employeeService, ILanguageService languageService,IAccountService accountService)
        {
            _employeeService = employeeService;
            _languageService = languageService;
            _accountService = accountService;

        }
        public async Task<IActionResult> Index()
        {
            var analysis = new object[6];
            var responseEmployee = await _employeeService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (responseEmployee != null && responseEmployee.IsSuccess) 
            {
                var data = JsonConvert.DeserializeObject<List<EmployeeDTO>>(Convert.ToString(responseEmployee.Result));
                analysis[0]=data.Count;
                analysis[1] = data.Where(n => n.Language.Name.ToLower() == "english").Count();
                analysis[2] = data.Where(n => n.Language.Name.ToLower() == "french").Count();
                analysis[3] = data.Where(n => n.Language.Name.ToLower() == "italian").Count();
            }
            var responseLanguage = await _languageService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (responseLanguage != null && responseLanguage.IsSuccess)
            {
                var data = JsonConvert.DeserializeObject<List<LanguageDTO>>(Convert.ToString(responseLanguage.Result));
                analysis[4] = data.Count;
            }
            var responseAccount= await _accountService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (responseAccount != null && responseAccount.IsSuccess)
            {
                var data = JsonConvert.DeserializeObject<List<AccountDTO>>(Convert.ToString(responseAccount.Result));
                analysis[5] = data.Count;
            }
            return View(analysis);
        }
    }
}
