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
                var users = await _UserQueries.GetUsers();
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

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(Guid id)
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
        public async Task<ActionResult> UserLogin([FromBody] UserDto userDto)
        {
            try
            {
                var command = new UserLoginCommand(userDto);
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
        public async Task<ActionResult> CreateUser([FromBody] UserDto userDto)
        {
            try
            {
                var command = new CreateUserCommand(userDto);
                var result = await _mediator.Send(command);
                if(result is not null)
                    return Ok(new APIResponseModel(true, 200, "Created Users successfully.", result));
            }
            catch (Exception ex)
            {
                _logger.LogError("User API_User Controller_CreateUser - Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
            return NoContent();
        }

        [HttpPost("update")]
        public async Task<ActionResult> UpdateUser([FromBody] UserDto updateUserDto)
        {
            try
            {
                var command = new UpdateUserCommand(updateUserDto);
                var result = await _mediator.Send(command);

                if (result is not null)
                    return Ok(new APIResponseModel(true, 200, "Updated User successfully."));
            }
            catch (Exception ex)
            {
                _logger.LogError("User API_User Controller_UpdateUser - Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }

            return NoContent();
        }

        [HttpDelete("{id}/delete")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            try
            {
                var command = new DeleteUserCommand(id);
                var result = await _mediator.Send(command);

                if (result)
                    return Ok(new APIResponseModel(true, 200, "Deleted User successfully."));
            }
            catch (Exception ex)
            {
                _logger.LogError("User API_User Controller_DeleteUser - Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }

            return NoContent();
        }

        [HttpPost("address/update")]
        public async Task<ActionResult> EditAddress([FromBody] AddressDto addressDto)
        {
            try
            {
                var command = new EditAddressCommand(addressDto);
                var result = await _mediator.Send(command);

                if (result)
                    return Ok(new APIResponseModel(true, 200, "Edit address successfully."));

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("User API_User Controller_UserLogin - Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpDelete("address/{id}/delete")]
        public async Task<ActionResult> DeleteAddress(Guid id)
        {
            try
            {
                var command = new DeleteAddressCommand(id);
                var result = await _mediator.Send(command);

                if (result)
                    return Ok(new APIResponseModel(true, 200, "Delete address successfully."));

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("User API_User Controller_UserLogin - Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }
    }
}