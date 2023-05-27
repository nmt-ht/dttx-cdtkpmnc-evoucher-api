using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class GetCampaignCommand : IRequest<CampaignDto>
    {
        public Guid Id { get; set; }
        public GetCampaignCommand(Guid id)
        {
            Id = id;
        }
    }
}
