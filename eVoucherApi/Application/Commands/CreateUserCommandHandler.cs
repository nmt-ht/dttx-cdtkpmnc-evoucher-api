using eVoucher.Service.Serivces;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class CreateUserCommandHandler: IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (request is null) return false;
            return  await _userService.UpdateUser(request.CreateUserDto);
        }
    }
}
