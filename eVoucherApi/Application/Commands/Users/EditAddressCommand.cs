using eVoucher.Service.Dtos;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class EditAddressCommand : IRequest<bool>
    {
        public AddressDto AddressDto { get; set; }
        public EditAddressCommand(AddressDto dto)
        {
            AddressDto = dto;
        }
    }
}
