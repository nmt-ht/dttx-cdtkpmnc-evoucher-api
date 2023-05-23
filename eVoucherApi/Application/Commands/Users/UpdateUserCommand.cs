using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class UpdateUserCommand : IRequest<User>
    {
        public UpdateUserDto UpdateUserDto { get; set; }
        public UpdateUserCommand(UpdateUserDto dto)
        {
            UpdateUserDto = dto;
        }
    }
}
