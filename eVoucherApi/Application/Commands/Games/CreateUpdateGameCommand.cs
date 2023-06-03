using eVoucher.Service.Dtos;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class CreateUpdateGameCommand : IRequest<bool>
    {
        public GameDto GameDto { get; set; }
        public CreateUpdateGameCommand(GameDto dto)
        {
            GameDto = dto;
        }
    }
}
