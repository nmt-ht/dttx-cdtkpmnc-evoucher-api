using eVoucher.Domain.Models;
using eVoucher.Service.Serivces;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class GetUserCommandHandler: IRequestHandler<GetUserCommand, User>
    {
        private readonly IUserService _userService;

        public GetUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User> Handle(GetUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserById(request.Id);
        }
    }
}
