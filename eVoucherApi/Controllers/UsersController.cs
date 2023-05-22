using eVoucher.Service.Dtos;
using eVoucher.Services.Api.Application.Queries;
using eVoucherApi.Application.Commands;
using eVoucherApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eVoucher.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private IUserQueries _UserQueries;
        private readonly IMediator _mediator;

        public UsersController(ILogger<UsersController> logger, IUserQueries UserQueries, IMediator mediator)
        {
            _logger = logger;
            _UserQueries = UserQueries;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                var Users = await _UserQueries.GetUsers();
                if (Users.Any())
                    return Ok(new APIResponseModel(true, 200, "Get Users successfully.", Users));

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("eVoucher API_Users Controller_Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser([FromQuery] Guid id = default)
        {
            try
            {
                var command = new GetUserCommand(id);
                var result = await _mediator.Send(command);
                if (result != null)
                    return Ok(new APIResponseModel(true, 200, "Get Users successfully.", result));

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("eVoucher API_Users Controller_Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> UserLogin([FromBody] UserDto UserDto)
        {
            try
            {
                var command = new UserLoginCommand(UserDto);
                var result = await _mediator.Send(command);

                if (result != null)
                    return Ok(new APIResponseModel(true, 200, "Get User Login successfully.", result));

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("User API_User Controller_UserLogin - Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateUser([FromBody] UserDto UserDto)
        {
            try
            {
                var command = new CreateUpdateUserCommand(UserDto);
                var result = await _mediator.Send(command);

                if (result != null)
                    return Ok(new APIResponseModel(true, 200, "Create User successfully.", result));

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("User API_User Controller_CreateUser - Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPost("update")]
        public async Task<ActionResult> UpdateUser([FromBody] UserDto UserDto)
        {
            try
            {
                var command = new CreateUpdateUserCommand(UserDto);
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("User API_User Controller_UpdateUser - Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPost("delete/{id}")]
        public async Task<ActionResult> DeleteUser([FromQuery] Guid id)
        {
            try
            {
                var command = new DeleteUserCommand(id);
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("User API_User Controller_DeleteUser - Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }
    }
}