using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;
using eVoucher.Service.Serivces;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class GetCampaignCommandHandler: IRequestHandler<GetCampaignCommand, CampaignDto>
    {
        private readonly ICampaignService _campaignService;

        public GetCampaignCommandHandler(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        public async Task<CampaignDto> Handle(GetCampaignCommand request, CancellationToken cancellationToken)
        {
            return await _campaignService.GetCampaignById(request.Id);
        }
    }
}
