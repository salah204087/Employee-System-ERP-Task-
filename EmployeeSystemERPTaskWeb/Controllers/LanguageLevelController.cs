using AutoMapper;
using EmployeeSystemERPTaskWeb.Model.DTO;
using EmployeeSystemERPTaskUtility;
using EmployeeSystemERPTaskWeb.Models;
using EmployeeSystemERPTaskWeb.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace EmployeeSystemERPTaskWeb.Controllers
{
    public class LanguageLevelController : Controller
    {
        private readonly ILanguageLevelService _languageLevelService;
        public LanguageLevelController(ILanguageLevelService languageLevelService)
        {
            _languageLevelService = languageLevelService;
        }
        public async Task<IActionResult> Index()
        {
            List<LanguageLevelDTO> list = new();
            var response = await _languageLevelService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
                list = JsonConvert.DeserializeObject<List<LanguageLevelDTO>>(Convert.ToString(response.Result));
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
        public async Task<IActionResult> Create(CreateLanguageLevelDTO createLanguageLevelDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _languageLevelService
                    .CreateAsync<APIResponse>(createLanguageLevelDTO, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Language Level Created Successfully";
                    return RedirectToAction("Index");
                }
            }
            TempData["error"] = "Error Encountered";
            return View(createLanguageLevelDTO);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update(int id)
        {
            var response = await _languageLevelService
                .GetAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                LanguageLevelDTO model = JsonConvert.DeserializeObject<LanguageLevelDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(LanguageLevelDTO languageLevelDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _languageLevelService
                    .UpdateAsync<APIResponse>(languageLevelDTO, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Language Level Updated Successfully";
                    return RedirectToAction("Index");
                }
            }
            TempData["error"] = "Error Encountered";
            return View(languageLevelDTO);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _languageLevelService
                .GetAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                LanguageLevelDTO model = JsonConvert.DeserializeObject<LanguageLevelDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(LanguageLevelDTO languageLevelDTO)
        {
            var response = await _languageLevelService
                .DeleteAsync<APIResponse>(languageLevelDTO.Id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Language Level Deleted Successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error Encountered.";
            return View(languageLevelDTO);
        }
    }
}
