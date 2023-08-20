using AutoMapper;
using EmployeeSystemERPTaskAPI.Model;
using EmployeeSystemERPTaskAPI.Model.DTO;
using EmployeeSystemERPTaskAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Employee_s_System_ERP_Task_API.Controllers
{
    [Route("api/AccountLineAPI")]
    [ApiController]
    public class AccountLineOfBusinessAPIController : ControllerBase
    {
        private readonly IAccount_LineOfBusinessRepository _accountLineContext;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public AccountLineOfBusinessAPIController(IAccount_LineOfBusinessRepository accountLineContext, IMapper mapper)
        {
            _accountLineContext = accountLineContext;
            _mapper = mapper;
            this._response = new APIResponse();
        }
        [HttpGet]
        [ResponseCache(Duration = 30)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<APIResponse> GetLineBusinessByAccount()
        {
            try
            {
                IEnumerable<Account_LineOfBusiness> account_LineOfBusinesses = _accountLineContext.GetAll();
                _response.Result = _mapper.Map<List<Account_LineOfBusinessDTO>>(account_LineOfBusinesses);
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
    }
}
