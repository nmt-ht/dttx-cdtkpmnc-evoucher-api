using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class UpdateCampaignCommand : IRequest<Campaign>
    {
        public UpdateCampaignDto UpdateCampaignDto { get; set; }
        public UpdateCampaignCommand(UpdateCampaignDto dto)
        {
            UpdateCampaignDto = dto;
        }
    }

}