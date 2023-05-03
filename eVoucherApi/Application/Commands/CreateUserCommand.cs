using eVoucher.Service.Dtos;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class CreateUserCommand : IRequest<bool>
    {
        public CreateUserDto CreateUserDto { get; set; }
        public CreateUserCommand(CreateUserDto dto)
        {
            CreateUserDto = dto;
        }
    }
}
