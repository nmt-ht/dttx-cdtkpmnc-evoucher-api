using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;
using eVoucher.Service.Serivces;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class UserLoginCommandHandler: IRequestHandler<UserLoginCommand, UserDto>
    {
        private readonly IUserService _userService;

        public UserLoginCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserDto> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            return await _userService.UserLogin(request.User);
        }
    }
}
