using eVoucher.Service.Dtos;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class DeleteCampaignCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DeleteCampaignCommand(Guid id)
        {
            Id = id;
        }
    }
}
