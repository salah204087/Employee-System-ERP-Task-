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
    [Route("api/AccountAPI")]
    [ApiController]
    public class AccountAPIController : ControllerBase
    {
        private readonly IAccountRepository _contextAccount;
        private readonly ILineOfBusinessRepository _contextLineOfBusiness;
        private readonly IAccount_LineOfBusinessRepository _contextAccountLineOfBusiness;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public AccountAPIController(IAccountRepository contextAccount, IMapper mapper, ILineOfBusinessRepository contextLineOfBusiness,IAccount_LineOfBusinessRepository contextAccountLineOfBusiness)
        {
            _contextAccount = contextAccount;
            _mapper = mapper;
            this._response = new APIResponse();
            _contextLineOfBusiness = contextLineOfBusiness;
            _contextAccountLineOfBusiness = contextAccountLineOfBusiness;

        }
        [HttpGet]
        [ResponseCache(Duration = 30)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<APIResponse> GetAccounts()
        {
            try
            {
                List<string> Properties = new List<string> { "Account_LineOfBusiness" };
                IEnumerable<Account> accounts = _contextAccount.GetAll(includeproperties:Properties);
                _response.Result = _mapper.Map<List<AccountDTO>>(accounts);
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
        [HttpGet("{id:int}", Name = "GetAccount")]
        [ResponseCache(Duration = 30)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<APIResponse> GetAccount(int id)
        {
            try
            {
                List<string> Properties = new List<string> { "Account_LineOfBusiness" };
                IEnumerable<Account> accounts = _contextAccount.GetAll(includeproperties: Properties);
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    return BadRequest();
                }
                var account = _contextAccount.Get(n => n.Id == id,includeproperties:Properties);
                if (account == null)
                {
                    _response.IsSuccess = false;
                    return NotFound();
                }
                _response.Result = _mapper.Map<AccountDTO>(account);
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
        public ActionResult<APIResponse> CreateAccount(CreateAccountDTO createAccountDTO)
        {
            try
            {
                if (_contextAccount.Get(n => n.Name.ToLower() == createAccountDTO.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("Error Message", "This Name of Account is already exist");
                    _response.IsSuccess = false;
                    return BadRequest(ModelState);
                }
                if (createAccountDTO == null)
                {
                    _response.IsSuccess = false;
                    return BadRequest(createAccountDTO);
                }
                var model = _mapper.Map<Account>(createAccountDTO);
                _contextAccount.Create(model);
                if (createAccountDTO.LineOfBusinessIds != null && createAccountDTO.LineOfBusinessIds.Any())
                {
                    foreach (var lineOfBusinessId in createAccountDTO.LineOfBusinessIds)
                    {
                        var lineOfBuiness = _contextLineOfBusiness.Get(n => n.Id == lineOfBusinessId);
                        var accountLineOfBusiness = new CreateAccount_LineOfBusinessDTO { AccountId = model.Id, Account = model, LineOfBusinessId = lineOfBusinessId, LineOfBusiness = lineOfBuiness, LineOfBusinessName = lineOfBuiness.Name };
                        var modelAccountLineOfBusiness = _mapper.Map<Account_LineOfBusiness>(accountLineOfBusiness);
                        _contextAccountLineOfBusiness.Create(modelAccountLineOfBusiness);
                    }
                }
                _response.Result = _mapper.Map<AccountDTO>(model);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetAccount", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete("{id:int}", Name = "DeleteAccount")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<APIResponse> DeleteAccount(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    return BadRequest();
                }
                var account = _contextAccount.Get(n => n.Id == id);
                if (account == null)
                {
                    _response.IsSuccess = false;
                    return NotFound();
                }
                _contextAccount.Remove(account);
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
        [HttpPut("{id:int}", Name = "UpdateAccount")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<APIResponse> UpdateAccount(int id, AccountDTO accountDTO)
        {
            try
            {
                if (accountDTO == null || id != accountDTO.Id)
                {
                    _response.IsSuccess = false;
                    return BadRequest();
                }

                var accountLineOfBusinesses = _contextAccountLineOfBusiness.GetAll();
                if (accountDTO.LineOfBusinessIds.Any())
                {
                    foreach (var item in accountLineOfBusinesses)
                    {
                        var existingAccountLineOfBusniess = _contextAccountLineOfBusiness.Get(gp => gp.AccountId == id);
                        if (existingAccountLineOfBusniess == null)
                            break;
                        _contextAccountLineOfBusiness.Remove(existingAccountLineOfBusniess);
                    }
                }

                var model = _mapper.Map<Account>(accountDTO);
                _contextAccount.Update(model);

                if (accountDTO.LineOfBusinessIds != null && accountDTO.LineOfBusinessIds.Any())
                {
                    foreach (var lineOfBuinessId in accountDTO.LineOfBusinessIds)
                    {
                        var lineOfBuiness = _contextLineOfBusiness.Get(n => n.Id == lineOfBuinessId);
                        var accountLineOfBusiness = new UpdateAccount_LineOfBusinessDTO { AccountId = model.Id, Account = model, LineOfBusinessId = lineOfBuinessId, LineOfBusiness = lineOfBuiness ,LineOfBusinessName=lineOfBuiness.Name};
                        var modelAccountLineOfBusiness = _mapper.Map<Account_LineOfBusiness>(accountLineOfBusiness);
                        _contextAccountLineOfBusiness.Create(modelAccountLineOfBusiness);
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