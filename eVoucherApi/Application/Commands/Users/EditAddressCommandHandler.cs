using eVoucher.Service.Serivces;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class EditAddressCommandHandler : IRequestHandler<EditAddressCommand, bool>
    {
        private readonly IUserService _userService;

        public EditAddressCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(EditAddressCommand request, CancellationToken cancellationToken)
        {
            return await _userService.EditAddress(request.AddressDto);
        }
    }
}
