using eVoucher.Service.Dtos;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class CreateUserCommand : IRequest<bool>
    {
        public UserDto UserDto { get; set; }
        public CreateUserCommand(UserDto dto)
        {
            UserDto = dto;
        }
    }
}
