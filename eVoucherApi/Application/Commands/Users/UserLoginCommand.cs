using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class UserLoginCommand : IRequest<UserDto>
    {
        public UserDto User { get; set; }
        public UserLoginCommand(UserDto user)
        {
            User = user;
        }
    }
}
