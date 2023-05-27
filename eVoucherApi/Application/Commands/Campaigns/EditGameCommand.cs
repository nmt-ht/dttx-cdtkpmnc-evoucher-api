using eVoucher.Service.Dtos;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class EditGameCommand : IRequest<bool>
    {
        public GameDto GameDto { get; set; }
        public EditGameCommand(GameDto dto)
        {
            GameDto = dto;
        }
    }
}
