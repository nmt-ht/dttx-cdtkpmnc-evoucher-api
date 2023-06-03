using eVoucher.Service.Serivces;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand, bool>
    {
        private readonly IGameService _gameService;

        public DeleteGameCommandHandler(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task<bool> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            if (request is null) return false;
            return await _gameService.DeleteGame(request.Id);
        }
    }
}
