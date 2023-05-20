using eVoucher.Service.Serivces;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class CreateUpdatePartnerCommandHandler : IRequestHandler<CreateUpdatePartnerCommand, bool>
    {
        private readonly IPartnerService _partnerService;

        public CreateUpdatePartnerCommandHandler(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        public async Task<bool> Handle(CreateUpdatePartnerCommand request, CancellationToken cancellationToken)
        {
            if (request is null) return false;
            return await _partnerService.UpdatePartner(request.PartnerDto);
        }
    }
}
