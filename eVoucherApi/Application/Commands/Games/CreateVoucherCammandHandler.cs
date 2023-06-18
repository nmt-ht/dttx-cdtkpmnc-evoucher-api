using eVoucher.Service.Serivces;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class CreateVoucherCammandHandler : IRequestHandler<CreateVoucherCammand, bool>
    {
        private IGameService _gameService;
        public CreateVoucherCammandHandler(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task<bool> Handle(CreateVoucherCammand request, CancellationToken cancellationToken)
        {
            if (request is null) return false;
            return await _gameService.CreateVoucher(request.VoucherDto);
        }
    }
}
