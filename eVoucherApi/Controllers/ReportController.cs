﻿using eVoucher.Services.Api.Application.Queries;
using eVoucherApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace eVoucherApi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IReportQueries _ReportQueries;
        private readonly IMediator _mediator;
        private readonly ILogger<ReportController> _logger;


        public ReportController(ILogger<ReportController> logger, IReportQueries ReportQueries, IMediator mediator)
        {
            _logger = logger;
            _ReportQueries = ReportQueries;
            _mediator = mediator;
        }

        [HttpPost("get-total-of-campaign-by-date")]
        public async Task<ActionResult> GetTotalOfCampaignByDate([FromBody] ReportCampaignRequest reportCampaignRequest)
        {
            try
            {
                var reports = await _ReportQueries.GetTotalOfCampaignByDate(reportCampaignRequest);
                if (reports.Any())
                    return Ok(new APIResponseModel(true, 200, "Get All Campaigns successfully.", reports));

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("eVoucher API_Users Controller_Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpGet("get-total-of-vouchers")]
        public async Task<ActionResult> GetTotalOfVouchers()
        {
            try
            {
                var reports = await _ReportQueries.GetTotalOfVouchers();
                if (reports.Any())
                    return Ok(new APIResponseModel(true, 200, "Get All Campaigns successfully.", reports));

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
