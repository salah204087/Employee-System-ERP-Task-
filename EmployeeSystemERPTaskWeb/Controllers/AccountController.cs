using AutoMapper;
using EmployeeSystemERPTaskUtility;
using EmployeeSystemERPTaskWeb.Model.DTO;
using EmployeeSystemERPTaskWeb.Models;
using EmployeeSystemERPTaskWeb.Models.VM;
using EmployeeSystemERPTaskWeb.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Data;

namespace EmployeeSystemERPTaskWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ILineOfBusinessService _lineOfBusinessService;
        private readonly IMapper _mapper;
        public AccountController(IAccountService accountService,IMapper mapper, ILineOfBusinessService lineOfBusinessService)
        {
            _accountService = accountService;
            _mapper = mapper;
            _lineOfBusinessService = lineOfBusinessService;

        }
        public async Task<IActionResult> Index()
        {
            List<AccountDTO> list = new();
            var response = await _accountService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                list = JsonConvert.DeserializeObject<List<AccountDTO>>(Convert.ToString(response.Result));
            return View(list);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create()
        {
            AccountCreateVM accountCreateVM = new();
            var businessLineResponse = await _lineOfBusinessService
                .GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (businessLineResponse != null && businessLineResponse.IsSuccess)
            {
                accountCreateVM.LineOfBusinessList = JsonConvert
                    .DeserializeObject<List<LineOfBusinessDTO>>(Convert.ToString(businessLineResponse.Result))
                    .Select(n => new SelectListItem
                    {
                        Text = n.Name,
                        Value = n.Id.ToString(),
                    });
            }
            return View(accountCreateVM);
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AccountCreateVM accountCreateVM)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService
                    .CreateAsync<APIResponse>(accountCreateVM.Account, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Account Created Successfully";
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
            var businessLineResponse = await _lineOfBusinessService
                .GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (businessLineResponse != null && businessLineResponse.IsSuccess)
            {
                accountCreateVM.LineOfBusinessList = JsonConvert
                    .DeserializeObject<List<LineOfBusinessDTO>>(Convert.ToString(businessLineResponse.Result))
                    .Select(n => new SelectListItem
                    {
                        Text = n.Name,
                        Value = n.Id.ToString(),
                    });
            }

            TempData["error"] = "Error Encountered.";
            return View(accountCreateVM);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update(int id)
        {
            AccountVM accountVM = new();
            var response = await _accountService.GetAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                AccountDTO model = JsonConvert.DeserializeObject<AccountDTO>(Convert.ToString(response.Result));
                accountVM.Account = _mapper.Map<AccountDTO>(model);
                var businessLineResponse = await _lineOfBusinessService
              .GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
                if (businessLineResponse != null && businessLineResponse.IsSuccess)
                {
                    accountVM.LineOfBusinessList = JsonConvert
                        .DeserializeObject<List<LineOfBusinessDTO>>(Convert.ToString(businessLineResponse.Result))
                        .Select(n => new SelectListItem
                        {
                            Text = n.Name,
                            Value = n.Id.ToString(),
                        });
                }
                return View(accountVM);
            }
            return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AccountVM accountVM)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.UpdateAsync<APIResponse>(accountVM.Account, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Account Updated Successfully";
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

            var businessLineResponse = await _lineOfBusinessService
              .GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (businessLineResponse != null && businessLineResponse.IsSuccess)
            {
                accountVM.LineOfBusinessList = JsonConvert
                    .DeserializeObject<List<LineOfBusinessDTO>>(Convert.ToString(businessLineResponse.Result))
                    .Select(n => new SelectListItem
                    {
                        Text = n.Name,
                        Value = n.Id.ToString(),
                    });
            }

            TempData["error"] = "Error Encountered.";
            return View(accountVM);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            AccountVM accountVM = new();
            var response = await _accountService.GetAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                AccountDTO model = JsonConvert.DeserializeObject<AccountDTO>(Convert.ToString(response.Result));
                accountVM.Account = _mapper.Map<AccountDTO>(model);
                var businessLineResponse = await _lineOfBusinessService
              .GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
                if (businessLineResponse != null && businessLineResponse.IsSuccess)
                {
                    accountVM.LineOfBusinessList = JsonConvert
                        .DeserializeObject<List<LineOfBusinessDTO>>(Convert.ToString(businessLineResponse.Result))
                        .Select(n => new SelectListItem
                        {
                            Text = n.Name,
                            Value = n.Id.ToString(),
                        });
                }
                return View(accountVM);
            }
            return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(AccountVM accountVM)
        {
            var response = await _accountService
                .DeleteAsync<APIResponse>(accountVM.Account.Id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Account Deleted Successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error Encountered.";
            return View(accountVM);
        }

    }
}
