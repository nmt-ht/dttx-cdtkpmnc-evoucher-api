using eVoucher.Service.Dtos;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class CreateUpdatePartnerCommand : IRequest<bool>
    {
        public PartnerDto PartnerDto { get; set; }
        public CreateUpdatePartnerCommand(PartnerDto dto)
        {
            PartnerDto = dto;
        }
    }
}
