using eVoucher.Service.Serivces;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class DeleteCampaignCommandHandler : IRequestHandler<DeleteCampaignCommand, bool>
    {
        private readonly ICampaignService _campaignService;

        public DeleteCampaignCommandHandler(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        public async Task<bool> Handle(DeleteCampaignCommand request, CancellationToken cancellationToken)
        {
            if (request is null) return false;
            return await _campaignService.DeleteCampaign(request.Id);
        }
    }
}
