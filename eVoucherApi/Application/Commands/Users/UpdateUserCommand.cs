using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class UpdateUserCommand : IRequest<UserDto>
    {
        public UserDto UpdateUserDto { get; set; }
        public UpdateUserCommand(UserDto dto)
        {
            UpdateUserDto = dto;
        }
    }
}
