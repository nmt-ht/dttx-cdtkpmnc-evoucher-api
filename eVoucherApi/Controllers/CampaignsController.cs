using eVoucher.Services.Api.Application.Queries;
using eVoucherApi.Application.Commands.Campaigns;
using eVoucherApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eVoucherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignsController : ControllerBase
    {
        private readonly ILogger<CampaignsController> _logger;
        private ICampaignQueries _campaignQueries;
        private readonly IMediator _mediator;

        public CampaignsController(ILogger<CampaignsController> logger, ICampaignQueries campaignQueries, IMediator mediator)
        {
            _logger = logger;
            _campaignQueries = campaignQueries;
            _mediator = mediator;
        }

        [HttpGet("campaign/{id}")]
        public async Task<ActionResult> GetCampaigns([FromQuery] Guid id)
        {
            try
            {
                //var command = new GetCampaignCommand(id);
                //var result = await _mediator.Send(command);

                //return Ok(result);
                var campaigns = await _campaignQueries.GetCampaigns();
                if (campaigns.Any())
                    return Ok(new APIResponseModel(true, 200, "Get Campaigns successfully.", campaigns));

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("eVoucher API_Campaigns Controller_Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }
    }
}
