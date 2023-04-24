using eVoucherApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace eVoucher.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Account> Get()
        {
            return new List<Account>();
        }
    }
}