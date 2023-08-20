using AutoMapper;
using EmployeeSystemERPTaskUtility;
using EmployeeSystemERPTaskWeb.Model.DTO;
using EmployeeSystemERPTaskWeb.Models;
using EmployeeSystemERPTaskWeb.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace EmployeeSystemERPTaskWeb.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageService _languageService;
        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }
        public async Task<IActionResult> Index()
        {
            List<LanguageDTO> list = new();
            var response = await _languageService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
                list = JsonConvert.DeserializeObject<List<LanguageDTO>>(Convert.ToString(response.Result));
            return View(list);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateLanguageDTO createLanguageDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _languageService
                    .CreateAsync<APIResponse>(createLanguageDTO, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Language Created Successfully";
                    return RedirectToAction("Index");
                }
            }
            TempData["error"] = "Error Encountered";
            return View(createLanguageDTO);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update(int id)
        {
            var response = await _languageService
                .GetAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                LanguageDTO model = JsonConvert.DeserializeObject<LanguageDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(LanguageDTO languageDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _languageService
                    .UpdateAsync<APIResponse>(languageDTO, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Language Updated Successfully";
                    return RedirectToAction("Index");
                }
            }
            TempData["error"] = "Error Encountered";
            return View(languageDTO);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _languageService
                .GetAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                LanguageDTO model = JsonConvert.DeserializeObject<LanguageDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(LanguageDTO languageDTO)
        {
            var response = await _languageService
                .DeleteAsync<APIResponse>(languageDTO.Id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Language Deleted Successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error Encountered.";
            return View(languageDTO);
        }
    }
}
