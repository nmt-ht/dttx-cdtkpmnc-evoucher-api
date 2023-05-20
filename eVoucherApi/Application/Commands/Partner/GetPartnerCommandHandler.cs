using eVoucher.Domain.Models;
using eVoucher.Service.Serivces;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class GetPartnerCommandHandler: IRequestHandler<GetPartnerCommand, Partner>
    {
        private readonly IPartnerService _partnerService;

        public GetPartnerCommandHandler(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        public Task<Partner> Handle(GetPartnerCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_partnerService.GetPartnerById(request.Id));
        }
    }
}
