using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class DeleteAddressCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DeleteAddressCommand(Guid id)
        {
            Id = id;
        }
    }
}
