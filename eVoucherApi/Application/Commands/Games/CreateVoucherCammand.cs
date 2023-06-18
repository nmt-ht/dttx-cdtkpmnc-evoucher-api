using eVoucher.Service.Dtos;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class CreateVoucherCammand : IRequest<bool>
    {
        public VoucherDto VoucherDto { get; set; }
        public CreateVoucherCammand(VoucherDto dto)
        {
            VoucherDto = dto;
        }
    }
}
