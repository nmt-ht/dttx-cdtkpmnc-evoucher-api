using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class GetGameCommand : IRequest<GameDto>
    {
        public Guid Id { get; set; }
        public GetGameCommand(Guid id)
        {
            Id = id;
        }
    }
}
