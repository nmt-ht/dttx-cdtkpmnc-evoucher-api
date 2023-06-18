using eVoucher.Service.Dtos;
using MediatR;

namespace eVoucherApi.Application.Commands.Campaigns
{
    public class CreateCampaignUserCammand : IRequest<bool>
    {
        public CampaignUserDto CampaignUserDto { get; set; }
        public CreateCampaignUserCammand(CampaignUserDto dto)
        {
            CampaignUserDto = dto;
        }
    }
}
