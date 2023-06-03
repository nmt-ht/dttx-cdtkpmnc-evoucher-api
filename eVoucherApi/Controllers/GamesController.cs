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
    public class GamesController : ControllerBase
    {
        private readonly ILogger<GamesController> _logger;
        private IGameQueries _gameQueries;
        private readonly IMediator _mediator;

        public GamesController(ILogger<GamesController> logger, IGameQueries gameQueries, IMediator mediator)
        {
            _logger = logger;
            _gameQueries = gameQueries;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetGames()
        {
            try
            {
                var Games = await _gameQueries.GetGames();
                if (Games.Any())
                    return Ok(new APIResponseModel(true, 200, "Get Games successfully.", Games));

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("eVoucher API_Games Controller_Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpGet("games/{id}")]
        public async Task<ActionResult> GetGame(Guid id)
        {
            try
            {
                var command = new GetGameCommand(id);
                var result = await _mediator.Send(command);

                if (result != null)
                    return Ok(new APIResponseModel(true, 200, "Get Games successfully.", result));

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("eVoucher API_Games Controller_Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateGame([FromBody] GameDto GameDto)
        {
            try
            {
                var command = new CreateUpdateGameCommand(GameDto);
                var result = await _mediator.Send(command);

                return Ok(new APIResponseModel(true, 200, "Create Game successfully.", result));
            }
            catch (Exception ex)
            {
                _logger.LogError("Game API_Game Controller_CreateGame - Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPost("update")]
        public async Task<ActionResult> UpdateGame([FromBody] GameDto GameDto)
        {
            try
            {
                var command = new CreateUpdateGameCommand(GameDto);
                var result = await _mediator.Send(command);

                return Ok(new APIResponseModel(true, 200, "Update Game successfully.", result));
            }
            catch (Exception ex)
            {
                _logger.LogError("Game API_Game Controller_UpdateGame - Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpDelete("{id}/delete")]
        public async Task<ActionResult> DeleteGame(Guid id)
        {
            try
            {
                var command = new DeleteGameCommand(id);
                var result = await _mediator.Send(command);

                return Ok(new APIResponseModel(true, 200, "delete Game successfully.", result));
            }
            catch (Exception ex)
            {
                _logger.LogError("Game API_Game Controller_DeleteGame - Exception: " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }
    }
}
