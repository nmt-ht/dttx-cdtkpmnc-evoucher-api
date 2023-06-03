using eVoucher.Service.Serivces;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class CreateUpdateGameCommandHandler : IRequestHandler<CreateUpdateGameCommand, bool>
    {
        private readonly IGameService _gameService;

        public CreateUpdateGameCommandHandler(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task<bool> Handle(CreateUpdateGameCommand request, CancellationToken cancellationToken)
        {
            if (request is null) return false;
            return await _gameService.UpdateGame(request.GameDto);
        }
    }
}
