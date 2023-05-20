using eVoucher.Domain.Models;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class GetUserCommand : IRequest<User>
    {
        public Guid Id { get; set; }
        public GetUserCommand(Guid id)
        {
            Id = id;
        }
    }
}
