using eVoucher.Service.Dtos;
using eVoucher.Service.Serivces;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class CheckUserCommandHandler : IRequestHandler<CheckUserCommand, bool>
    {
        private readonly IUserService _userService;

        public CheckUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(CheckUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userService.CheckUser(request.Email);
            return result;
        }
    }
}
