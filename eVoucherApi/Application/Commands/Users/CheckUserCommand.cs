using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class CheckUserCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public CheckUserCommand(string email)
        {
            Email = email;
        }
    }
}
