using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;
using eVoucher.Service.Serivces;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class GetUserCommandHandler: IRequestHandler<GetUserCommand, UserDto>
    {
        private readonly IUserService _userService;

        public GetUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserDto> Handle(GetUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserById(request.Id);
        }
    }
}
