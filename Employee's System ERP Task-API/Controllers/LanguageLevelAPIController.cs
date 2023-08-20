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
    [Route("api/LanguageLevelAPI")]
    [ApiController]
    public class LanguageLevelAPIController : ControllerBase
    {
        private readonly ILanguageLevelRepository _contextLanguageLevel;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public LanguageLevelAPIController(ILanguageLevelRepository contextLanguageLevel,IMapper mapper)
        {
            _contextLanguageLevel = contextLanguageLevel;
            _mapper = mapper;
            this._response = new APIResponse();
        }
        [HttpGet]
        [ResponseCache(Duration = 30)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<APIResponse> GetLanguageLevels()
        {
            try
            {
                IEnumerable<LanguageLevel> languageLevels = _contextLanguageLevel.GetAll();
                _response.Result = _mapper.Map<List<LanguageLevelDTO>>(languageLevels);
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
        [HttpGet("{id:int}", Name = "GetLanguageLevel")]
        [ResponseCache(Duration = 30)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<APIResponse> GetLanguageLevel(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    return BadRequest();
                }
                var languageLevel = _contextLanguageLevel.Get(n => n.Id == id);
                if (languageLevel == null)
                {
                    _response.IsSuccess = false;
                    return NotFound();
                }
                _response.Result = _mapper.Map<LanguageLevelDTO>(languageLevel);
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
        public ActionResult<APIResponse> CreateLanguageLevel(CreateLanguageLevelDTO createLanguageLevelDTO)
        {
            try
            {
                if (_contextLanguageLevel.Get(n => n.Name.ToLower() == createLanguageLevelDTO.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("Error Message", "This Name of language level is already exist");
                    _response.IsSuccess = false;
                    return BadRequest(ModelState);
                }
                if (createLanguageLevelDTO == null)
                {
                    _response.IsSuccess = false;
                    return BadRequest(createLanguageLevelDTO);
                }
                var model = _mapper.Map<LanguageLevel>(createLanguageLevelDTO);
                _contextLanguageLevel.Create(model);
                _response.Result = _mapper.Map<LanguageLevelDTO>(model);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetLanguageLevel", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete("{id:int}", Name = "DeleteLanguageLevel")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<APIResponse> DeleteLanguageLevel(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    return BadRequest();
                }
                var languageLevel = _contextLanguageLevel.Get(n => n.Id == id);
                if (languageLevel == null)
                {
                    _response.IsSuccess = false;
                    return NotFound();
                }
                _contextLanguageLevel.Remove(languageLevel);
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
        [HttpPut("{id:int}", Name = "UpdateLanguageLevel")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<APIResponse> UpdateLanguageLevel(int id, LanguageLevelDTO languageLevelDTO)
        {
            try
            {
                if (languageLevelDTO == null || id != languageLevelDTO.Id)
                {
                    _response.IsSuccess = false;
                    return BadRequest();
                }
                var model = _mapper.Map<LanguageLevel>(languageLevelDTO);
                _contextLanguageLevel.Update(model);
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