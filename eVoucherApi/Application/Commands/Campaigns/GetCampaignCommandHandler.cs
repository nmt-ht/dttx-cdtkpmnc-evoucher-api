using eVoucher.Domain.Models;
using eVoucher.Service.Serivces;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class GetCampaignCommandHandler: IRequestHandler<GetCampaignCommand, Campaign>
    {
        private readonly ICampaignService _campaignService;

        public GetCampaignCommandHandler(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        public Task<Campaign> Handle(GetCampaignCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_campaignService.GetCampaignById(request.Id));
        }
    }
}
