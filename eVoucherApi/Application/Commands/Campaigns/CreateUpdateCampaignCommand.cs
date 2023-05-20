using eVoucher.Service.Dtos;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class CreateUpdateCampaignCommand : IRequest<bool>
    {
        public CampaignDto CampaignDto { get; set; }
        public CreateUpdateCampaignCommand(CampaignDto dto)
        {
            CampaignDto = dto;
        }
    }
}
