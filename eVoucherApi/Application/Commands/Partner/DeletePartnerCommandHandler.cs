using eVoucher.Service.Serivces;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class DeletePartnerCommandHandler : IRequestHandler<DeletePartnerCommand, bool>
    {
        private readonly IPartnerService _partnerService;

        public DeletePartnerCommandHandler(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        public async Task<bool> Handle(DeletePartnerCommand request, CancellationToken cancellationToken)
        {
            if (request is null) return false;
            return await _partnerService.DeletePartner(request.Id);
        }
    }
}
