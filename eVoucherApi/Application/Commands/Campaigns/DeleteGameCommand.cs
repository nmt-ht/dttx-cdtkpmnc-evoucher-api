using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class DeleteGameCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DeleteGameCommand(Guid id)
        {
            Id = id;
        }
    }
}
