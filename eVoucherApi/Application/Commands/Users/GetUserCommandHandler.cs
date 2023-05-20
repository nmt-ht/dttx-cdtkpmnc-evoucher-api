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

        public Task<User> Handle(GetUserCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_userService.GetUserById(request.Id));
        }
    }
}
