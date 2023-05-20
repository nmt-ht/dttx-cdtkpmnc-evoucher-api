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
    public class PartnersController : ControllerBase
    {
        private readonly ILogger<PartnersController> _logger;
        private IPartnerQueries _partnerQueries;
        private readonly IMediator _mediator;

        public PartnersController(ILogger<PartnersController> logger, IPartnerQueries partnerQueries, IMediator mediator)
        {
            _logger = logger;
            _partnerQueries = partnerQueries;
            _mediator = mediator;
        }

        [HttpGet("partners")]
        public async Task<ActionResult> GetPartners()
        {
            try
            {
                var Partners = await _partnerQueries.GetPartners();
                if (Partners.Any())
                    return Ok(new APIResponseModel(true, 200, "Get Partners successfully.", Partners));

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("eVoucher API_Partners Controller_Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpGet("Partner/{id}")]
        public async Task<ActionResult> GetPartners([FromQuery] Guid id)
        {
            try
            {
                var command = new GetPartnerCommand(id);
                var result = await _mediator.Send(command);

                if (result != null)
                    return Ok(new APIResponseModel(true, 200, "Get Partners successfully.", result));

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("eVoucher API_Partners Controller_Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreatePartner([FromBody] PartnerDto PartnerDto)
        {
            try
            {
                var command = new CreateUpdatePartnerCommand(PartnerDto);
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Partner API_Partner Controller_CreatePartner - Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPost("update")]
        public async Task<ActionResult> UpdatePartner([FromBody] PartnerDto PartnerDto)
        {
            try
            {
                var command = new CreateUpdatePartnerCommand(PartnerDto);
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Partner API_Partner Controller_UpdatePartner - Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPost("delete/{id}")]
        public async Task<ActionResult> DeletePartner([FromQuery] Guid id)
        {
            try
            {
                var command = new DeletePartnerCommand(id);
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Partner API_Partner Controller_DeletePartner - Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }
    }
}
