using eVoucher.Service.Serivces;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class CreateUpdateCampaignCommandHandler : IRequestHandler<CreateUpdateCampaignCommand, bool>
    {
        private readonly ICampaignService _campaignService;

        public CreateUpdateCampaignCommandHandler(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        public async Task<bool> Handle(CreateUpdateCampaignCommand request, CancellationToken cancellationToken)
        {
            if (request is null) return false;
            return await _campaignService.UpdateCampaign(request.CampaignDto);
        }
    }
}
