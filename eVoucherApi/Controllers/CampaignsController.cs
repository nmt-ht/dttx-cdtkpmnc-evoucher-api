using eVoucher.Service.Dtos;
using eVoucher.Services.Api.Application.Queries;
using eVoucherApi.Application.Commands;
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

        [HttpGet]
        public async Task<ActionResult> GetCampaigns()
        {
            try
            {
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

        [HttpGet("campaign/{id}")]
        public async Task<ActionResult> GetCampaign([FromQuery] Guid id)
        {
            try
            {
                var command = new GetCampaignCommand(id);
                var result = await _mediator.Send(command);

                if (result != null)
                    return Ok(new APIResponseModel(true, 200, "Get Campaign by Id successfully.", result));

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("eVoucher API_Campaigns Controller_Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateCampaign([FromBody] CampaignDto CampaignDto)
        {
            try
            {
                var command = new CreateUpdateCampaignCommand(CampaignDto);
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Campaign API_Campaign Controller_CreateCampaign - Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPost("update")]
        public async Task<ActionResult> UpdateCampaign([FromBody] CampaignDto CampaignDto)
        {
            try
            {
                var command = new CreateUpdateCampaignCommand(CampaignDto);
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Campaign API_Campaign Controller_UpdateCampaign - Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPost("delete/{id}")]
        public async Task<ActionResult> DeleteCampaign([FromQuery] Guid id)
        {
            try
            {
                var command = new DeleteCampaignCommand(id);
                var result = await _mediator.Send(command);

                return Ok(result);
            }


            catch (Exception ex)
            {
                _logger.LogError("Campaign API_Campaign Controller_DeleteCampaign - Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }
    }
}
