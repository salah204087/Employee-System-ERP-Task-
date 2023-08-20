using AutoMapper;
using Azure;
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
    [Route("api/LineOfBusinessAPI")]
    [ApiController]
    public class LineOfBusinessAPIController : ControllerBase
    {
        private readonly ILineOfBusinessRepository _contextLineOfBusiness;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public LineOfBusinessAPIController(ILineOfBusinessRepository contextLineOfBusiness,IMapper mapper)
        {
            _contextLineOfBusiness = contextLineOfBusiness;
            _mapper = mapper;
            this._response= new APIResponse();
        }
        [HttpGet]
        [ResponseCache(Duration = 30)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<APIResponse> GetLineOfBusiness()
        {
            try
            {
                IEnumerable<LineOfBusiness> lineOfBusinesses = _contextLineOfBusiness.GetAll();
                _response.Result = _mapper.Map<List<LineOfBusinessDTO>>(lineOfBusinesses);
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
        [HttpGet("{id:int}", Name = "GetLineOfBusiness")]
        [ResponseCache(Duration = 30)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<APIResponse> GetLineOfBusiness(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    return BadRequest();
                }
                var lineOfBusiness = _contextLineOfBusiness.Get(n => n.Id == id);
                if (lineOfBusiness == null)
                {
                    _response.IsSuccess = false;
                    return NotFound();
                }
                _response.Result = _mapper.Map<LineOfBusinessDTO>(lineOfBusiness);
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
        public ActionResult<APIResponse> CreateLineOfBusiness(LineOfBusinessCreateDTO lineOfBusinessCreateDTO)
        {
            try
            {
                if (_contextLineOfBusiness.Get(n => n.Name.ToLower() == lineOfBusinessCreateDTO.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("Error Message", "This Name of language is already exist");
                    _response.IsSuccess = false;
                    return BadRequest(ModelState);
                }
                if (lineOfBusinessCreateDTO == null)
                {
                    _response.IsSuccess = false;
                    return BadRequest(lineOfBusinessCreateDTO);
                }
                var model = _mapper.Map<LineOfBusiness>(lineOfBusinessCreateDTO);
                _contextLineOfBusiness.Create(model);
                _response.Result = _mapper.Map<LineOfBusinessDTO>(model);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetLineOfBusiness", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete("{id:int}", Name = "DeleteLineOfBusiness")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<APIResponse> DeleteLineOfBusiness(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    return BadRequest();
                }
                var lineOfBusiness = _contextLineOfBusiness.Get(n => n.Id == id);
                if (lineOfBusiness == null)
                {
                    _response.IsSuccess = false;
                    return NotFound();
                }
                _contextLineOfBusiness.Remove(lineOfBusiness);
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
        [HttpPut("{id:int}", Name = "UpdateLineOfBusiness")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<APIResponse> UpdateLineOfBusiness(int id, LineOfBusinessDTO lineOfBusinessDTO)
        {
            try
            {
                if (lineOfBusinessDTO == null || id != lineOfBusinessDTO.Id)
                {
                    _response.IsSuccess = false;
                    return BadRequest();
                }
                var model = _mapper.Map<LineOfBusiness>(lineOfBusinessDTO);
                _contextLineOfBusiness.Update(model);
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
