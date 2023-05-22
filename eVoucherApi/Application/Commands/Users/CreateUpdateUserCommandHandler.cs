using eVoucher.Domain.Models;
using eVoucher.Service.Serivces;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class CreateUpdateUserCommandHandler : IRequestHandler<CreateUpdateUserCommand, User>
    {
        private readonly IUserService _userService;

        public CreateUpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User> Handle(CreateUpdateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userService.UpdateUser(request.UserDto);
            return result;
        }
    }
}
