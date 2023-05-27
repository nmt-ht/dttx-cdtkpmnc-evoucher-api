using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public UserDto UserDto { get; set; }
        public CreateUserCommand(UserDto dto)
        {
            UserDto = dto;
        }
    }
}
