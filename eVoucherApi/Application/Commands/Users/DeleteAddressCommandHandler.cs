using eVoucher.Service.Serivces;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, bool>
    {
        private readonly IUserService _userService;

        public DeleteAddressCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var result = await _userService.DeleteAddress(request.Id);
            return result;
        }
    }
}
