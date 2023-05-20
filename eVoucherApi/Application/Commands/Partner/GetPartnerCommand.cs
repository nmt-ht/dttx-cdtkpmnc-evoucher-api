using eVoucher.Domain.Models;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class GetPartnerCommand : IRequest<Partner>
    {
        public Guid Id { get; set; }
        public GetPartnerCommand(Guid id)
        {
            Id = id;
        }
    }
}
