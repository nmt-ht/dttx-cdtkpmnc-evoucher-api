using eVoucher.Services.Api.Application.Queries;
using eVoucherApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace eVoucher.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private IUserQueries _UserQueries;
        public UsersController(ILogger<UsersController> logger, IUserQueries UserQueries)
        {
            _logger = logger;
            _UserQueries = UserQueries;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers([FromQuery] Guid id = default)
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
    }
}