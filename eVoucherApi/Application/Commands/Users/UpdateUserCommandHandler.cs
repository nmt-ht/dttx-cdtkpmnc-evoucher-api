using eVoucher.Service.Dtos;
using eVoucher.Service.Serivces;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
    {
        private readonly IUserService _userService;

        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userService.UpdateUser(request.UpdateUserDto);
            return result;
        }
    }
}
