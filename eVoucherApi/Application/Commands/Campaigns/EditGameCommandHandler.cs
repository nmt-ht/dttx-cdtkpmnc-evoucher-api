using eVoucher.Service.Serivces;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class EditGameCommandHandler : IRequestHandler<EditAddressCommand, bool>
    {
        private readonly IUserService _userService;

        public EditGameCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(EditAddressCommand request, CancellationToken cancellationToken)
        {
            return await _userService.EditAddress(request.AddressDto);
        }
    }
}
