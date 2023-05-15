using eVoucher.Domain.Models;
using MediatR;

namespace eVoucherApi.Application.Commands.Campaigns
{
    public class GetCampaignCommand : IRequest<Campaign>
    {
        public Guid Id { get; set; }
        public GetCampaignCommand(Guid id)
        {
            Id = id;
        }
    }
}
