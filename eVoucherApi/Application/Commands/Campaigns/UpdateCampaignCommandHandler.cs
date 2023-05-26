using eVoucher.Domain.Models;
using eVoucher.Service.Serivces;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class UpdateCampaignCommandHandler : IRequestHandler<UpdateCampaignCommand, Campaign>
    {
        private readonly IUserService _userService;

        public UpdateCampaignCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Campaign> Handle(UpdateCampaignCommand request, CancellationToken cancellationToken)
        {
            var result = await _userService.UpdateCampaign(request.UpdateCampaignDto);
            return result;
        }
    }
        
}
