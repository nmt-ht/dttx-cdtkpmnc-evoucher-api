using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class CreateUpdateUserCommand : IRequest<User>
    {
        public UserDto UserDto { get; set; }
        public CreateUpdateUserCommand(UserDto dto)
        {
            UserDto = dto;
        }
    }
}
