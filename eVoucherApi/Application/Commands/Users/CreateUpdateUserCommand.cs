using eVoucher.Service.Dtos;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class CreateUpdateUserCommand : IRequest<bool>
    {
        public UserDto UserDto { get; set; }
        public CreateUpdateUserCommand(UserDto dto)
        {
            UserDto = dto;
        }
    }
}
