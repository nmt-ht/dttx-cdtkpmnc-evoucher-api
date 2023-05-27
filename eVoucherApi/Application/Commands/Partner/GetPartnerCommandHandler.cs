using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;
using eVoucher.Service.Serivces;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class GetPartnerCommandHandler: IRequestHandler<GetPartnerCommand, PartnerDto>
    {
        private readonly IPartnerService _partnerService;

        public GetPartnerCommandHandler(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        public async Task<PartnerDto> Handle(GetPartnerCommand request, CancellationToken cancellationToken)
        {
            return await _partnerService.GetPartnerById(request.Id);
        }
    }
}
