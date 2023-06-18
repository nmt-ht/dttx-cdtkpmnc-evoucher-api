using eVoucher.Service.Serivces;
using MediatR;

namespace eVoucherApi.Application.Commands.Campaigns
{
    public class CreateCampaignUserCammandHanlder : IRequestHandler<CreateCampaignUserCammand, bool>
    {
        private readonly ICampaignService _campaignService;

        public CreateCampaignUserCammandHanlder(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        public async Task<bool> Handle(CreateCampaignUserCammand request, CancellationToken cancellationToken)
        {
            if (request is null) return false;
            return await _campaignService.UpdateCampaignUser(request.CampaignUserDto);
        }
    }
}
