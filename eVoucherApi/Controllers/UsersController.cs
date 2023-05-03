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
        public async Task<ActionResult> GetUsers([FromQuery] Guid id = default)
        {
            try
            {
                var users = await _UserQueries.GetUsers(id);
                if (users.Any())
                    return Ok(new APIResponseModel(true, 200, "Get Users successfully.", users));

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("eVoucher API_Users Controller_Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateUser([FromBody] UserDto UserDto)
        {
            try
            {
                var command = new CreateUserCommand(UserDto);
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("User API_User Controller_CreateUser - Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }
    }
}