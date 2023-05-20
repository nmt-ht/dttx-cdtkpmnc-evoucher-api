using eVoucher.Service.Dtos;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }
    }
}
