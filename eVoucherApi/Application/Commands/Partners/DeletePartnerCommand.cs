using eVoucher.Service.Dtos;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class DeletePartnerCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DeletePartnerCommand(Guid id)
        {
            Id = id;
        }
    }
}
