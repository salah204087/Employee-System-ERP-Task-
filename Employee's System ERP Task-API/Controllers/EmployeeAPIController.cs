using AutoMapper;
using EmployeeSystemERPTaskAPI.Model;
using EmployeeSystemERPTaskAPI.Model.DTO;
using EmployeeSystemERPTaskAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace EmployeeSystemERPTaskAPI.Controllers
{
    [Route("api/EmployeeAPI")]
    [ApiController]
    public class EmployeeAPIController : ControllerBase
    {
        private readonly IEmployeeRepository _contextEmployee;
        private readonly ILanguageLevelRepository _contextLangLevel;
        private readonly IEmployeeLangLevelRepository _contextEmployeeLangLevel;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public EmployeeAPIController(IEmployeeRepository contextEmployee,IMapper mapper, ILanguageLevelRepository contextLangLevel, IEmployeeLangLevelRepository contextEmployeeLangLevel)
        {
            _contextEmployee = contextEmployee;
            _mapper = mapper;
            this._response = new APIResponse();
            _contextLangLevel = contextLangLevel;
            _contextEmployeeLangLevel = contextEmployeeLangLevel;
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        [ResponseCache(Duration = 30)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<APIResponse> GetEmployess()
        {
            try
            {
                List<string> Properties = new List<string> { "Account","Language", "EmployeeLangLevels", "BusinessLine" };
                IEnumerable<Employee> employees = _contextEmployee.GetAll(includeproperties: Properties);
                _response.Result = _mapper.Map<List<EmployeeDTO>>(employees);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("{id:int}", Name = "GetEmployee")]
        [Authorize(Roles = "admin")]
        [ResponseCache(Duration = 30)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<APIResponse> GetEmployee(int id)
        {
            try
            {
                List<string> Properties = new List<string> { "Account", "Language", "EmployeeLangLevels", "BusinessLine" };
                IEnumerable<Employee> employees = _contextEmployee.GetAll(includeproperties: Properties);
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    return BadRequest();
                }
                var employee = _contextEmployee.Get(n => n.Id == id, includeproperties: Properties);
                if (employee == null)
                {
                    _response.IsSuccess = false;
                    return NotFound();
                }
                _response.Result = _mapper.Map<EmployeeDTO>(employee);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<APIResponse> CreateEmployee(CreateEmployeeDTO createEmployeeDTO)
        {
            try
            {
                if (_contextEmployee.Get(n => n.Name.ToLower() == createEmployeeDTO.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("Error Message", "This Name of Employee is already exist");
                    _response.IsSuccess = false;
                    return BadRequest(ModelState);
                }
                if (createEmployeeDTO == null)
                {
                    _response.IsSuccess = false;
                    return BadRequest(createEmployeeDTO);
                }
                var model = _mapper.Map<Employee>(createEmployeeDTO);
                _contextEmployee.Create(model);
                if (createEmployeeDTO.LanguageLevelIds != null && createEmployeeDTO.LanguageLevelIds.Any())
                {
                    foreach (var languageLevelId in createEmployeeDTO.LanguageLevelIds)
                    {
                        var employeeLangLevel = new CreateEmployeeLangLevelDTO { EmployeeId = model.Id, LanguageLevelId = languageLevelId };
                        var languageLevel = _contextLangLevel.Get(n => n.Id == languageLevelId);
                        var modelemployeeLangLevel = new EmployeeLangLevel { EmployeeId = model.Id, LanguageLevelId = languageLevelId, Employee = model, LanguageLevel = languageLevel,LanguageLevelName=languageLevel.Name };
                        _contextEmployeeLangLevel.Create(modelemployeeLangLevel);
                    }
                }
                _response.Result = _mapper.Map<EmployeeDTO>(model);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetEmployee", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete("{id:int}", Name = "DeleteEmployee")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<APIResponse> DeleteEmployee(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    return BadRequest();
                }
                var employee = _contextEmployee.Get(n => n.Id == id);
                if (employee == null)
                {
                    _response.IsSuccess = false;
                    return NotFound();
                }
                _contextEmployee.Remove(employee);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
        [HttpPut("{id:int}", Name = "UpdateEmployee")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<APIResponse> UpdateEmployee(int id, UpdateEmployeeDTO updateEmployeeDTO)
        {
            try
            {
                if (updateEmployeeDTO == null || id != updateEmployeeDTO.Id)
                {
                    _response.IsSuccess = false;
                    return BadRequest();
                }

                var employeeLangLevels = _contextEmployeeLangLevel.GetAll();
                if (updateEmployeeDTO.LanguageLevelIds.Any())
                {
                    foreach (var item in employeeLangLevels)
                    {
                        var existingEmployeeLangLevel = _contextEmployeeLangLevel.Get(gp => gp.EmployeeId == id);
                        if (existingEmployeeLangLevel == null)
                            break;
                        _contextEmployeeLangLevel.Remove(existingEmployeeLangLevel);
                    }
                }

                var model = _mapper.Map<Employee>(updateEmployeeDTO);
                _contextEmployee.Update(model);

                if (updateEmployeeDTO.LanguageLevelIds != null && updateEmployeeDTO.LanguageLevelIds.Any())
                {
                    foreach (var langLevelId in updateEmployeeDTO.LanguageLevelIds)
                    {
                        var languageLevel = _contextLangLevel.Get(n => n.Id == langLevelId);
                        var employeeLangLevel = new UpdateEmployeeLangLevelDTO { EmployeeId = model.Id, Employee = model, LanguageLevelId = langLevelId, LanguageLevel = languageLevel,LanguageLevelName=languageLevel.Name };
                        var modelAccountEmployeeLangLevel = _mapper.Map<EmployeeLangLevel>(employeeLangLevel);
                        _contextEmployeeLangLevel.Create(modelAccountEmployeeLangLevel);
                    }
                }

                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
    }
}
