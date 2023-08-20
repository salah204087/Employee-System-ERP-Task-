using AutoMapper;
using EmployeeSystemERPTaskUtility;
using EmployeeSystemERPTaskWeb.Model.DTO;
using EmployeeSystemERPTaskWeb.Models;
using EmployeeSystemERPTaskWeb.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeSystemERPTaskWeb.Controllers
{
    public class LineOfBusinessController : Controller
    {
        private readonly ILineOfBusinessService _lineOfBusinessService;
        public LineOfBusinessController(ILineOfBusinessService lineOfBusinessService)
        {
            _lineOfBusinessService=lineOfBusinessService;
        }
        public async Task<IActionResult> Index()
        {
            List<LineOfBusinessDTO> list = new();
            var response = await _lineOfBusinessService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
                list = JsonConvert.DeserializeObject<List<LineOfBusinessDTO>>(Convert.ToString(response.Result));
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
        public async Task<IActionResult> Create(LineOfBusinessCreateDTO lineOfBusinessCreateDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _lineOfBusinessService
                    .CreateAsync<APIResponse>(lineOfBusinessCreateDTO, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Line if business Created Successfully";
                    return RedirectToAction("Index");
                }
            }
            TempData["error"] = "Error Encountered";
            return View(lineOfBusinessCreateDTO);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update(int id)
        {
            var response = await _lineOfBusinessService
                .GetAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                LineOfBusinessDTO model = JsonConvert.DeserializeObject<LineOfBusinessDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(LineOfBusinessDTO lineOfBusinessDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _lineOfBusinessService
                    .UpdateAsync<APIResponse>(lineOfBusinessDTO, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Line of business Updated Successfully";
                    return RedirectToAction("Index");
                }
            }
            TempData["error"] = "Error Encountered";
            return View(lineOfBusinessDTO);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _lineOfBusinessService
                .GetAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                LineOfBusinessDTO model = JsonConvert.DeserializeObject<LineOfBusinessDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(LineOfBusinessDTO lineOfBusinessDTO)
        {
            var response = await _lineOfBusinessService
                .DeleteAsync<APIResponse>(lineOfBusinessDTO.Id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Line of business Deleted Successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error Encountered.";
            return View(lineOfBusinessDTO);
        }
    }
}
