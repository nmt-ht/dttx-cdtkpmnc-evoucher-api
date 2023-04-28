using eVoucherApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace eVoucher.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Account> GetAccounts()
        {
            return new List<Account>();
        }
    }
}