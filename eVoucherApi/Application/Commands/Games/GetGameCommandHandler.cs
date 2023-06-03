using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;
using eVoucher.Service.Serivces;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class GetGameCommandHandler: IRequestHandler<GetGameCommand, GameDto>
    {
        private readonly IGameService _gameService;

        public GetGameCommandHandler(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task<GameDto> Handle(GetGameCommand request, CancellationToken cancellationToken)
        {
            return await _gameService.GetGameById(request.Id);
        }
    }
}
