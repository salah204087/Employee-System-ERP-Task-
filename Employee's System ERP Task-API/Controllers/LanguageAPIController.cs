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
    [Route("api/LanguageAPI")]
    [ApiController]
    public class LanguageAPIController : ControllerBase
    {
        private readonly ILanguageRepository _contextLanguage;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public LanguageAPIController(ILanguageRepository contextLanguage,IMapper mapper)
        {
            _contextLanguage = contextLanguage;
            _mapper = mapper;
            this._response = new APIResponse();
        }
        [HttpGet]
        [ResponseCache(Duration = 30)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<APIResponse> GetLanguages()
        {
            try
            {
                IEnumerable<Language> languages = _contextLanguage.GetAll();
                _response.Result = _mapper.Map<List<LanguageDTO>>(languages);
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
        [HttpGet("{id:int}", Name = "GetLanguage")]
        [ResponseCache(Duration = 30)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<APIResponse> GetLanguage(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    return BadRequest();
                }
                var language = _contextLanguage.Get(n => n.Id == id);
                if (language == null)
                {
                    _response.IsSuccess = false;
                    return NotFound();
                }
                _response.Result = _mapper.Map<LanguageDTO>(language);
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
        public ActionResult<APIResponse> CreateLanguage(CreateLanguageDTO createLanguageDTO)
        {
            try
            {
                if (_contextLanguage.Get(n => n.Name.ToLower() == createLanguageDTO.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("Error Message", "This Name of language is already exist");
                    _response.IsSuccess = false;
                    return BadRequest(ModelState);
                }
                if (createLanguageDTO == null)
                {
                    _response.IsSuccess = false;
                    return BadRequest(createLanguageDTO);
                }
                var model = _mapper.Map<Language>(createLanguageDTO);
                _contextLanguage.Create(model);
                _response.Result = _mapper.Map<LanguageDTO>(model);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetLanguage", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete("{id:int}", Name = "DeleteLanguage")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<APIResponse> DeleteLanguage(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    return BadRequest();
                }
                var language = _contextLanguage.Get(n => n.Id == id);
                if (language == null)
                {
                    _response.IsSuccess = false;
                    return NotFound();
                }
                _contextLanguage.Remove(language);
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
        [HttpPut("{id:int}", Name = "UpdateLanguage")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<APIResponse> UpdateLanguage(int id, LanguageDTO languageDTO)
        {
            try
            {
                if (languageDTO == null || id != languageDTO.Id)
                {
                    _response.IsSuccess = false;
                    return BadRequest();
                }
                var model = _mapper.Map<Language>(languageDTO);
                _contextLanguage.Update(model);
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