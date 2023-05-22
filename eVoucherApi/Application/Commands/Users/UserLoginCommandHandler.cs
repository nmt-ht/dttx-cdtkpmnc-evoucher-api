using eVoucher.Domain.Models;
using eVoucher.Service.Serivces;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class UserLoginCommandHandler: IRequestHandler<UserLoginCommand, User>
    {
        private readonly IUserService _userService;

        public UserLoginCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public Task<User> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_userService.UserLogin(request.User));
        }
    }
}
