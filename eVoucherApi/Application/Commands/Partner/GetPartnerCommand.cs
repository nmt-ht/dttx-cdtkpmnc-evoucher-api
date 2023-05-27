using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class GetPartnerCommand : IRequest<PartnerDto>
    {
        public Guid Id { get; set; }
        public GetPartnerCommand(Guid id)
        {
            Id = id;
        }
    }
}
