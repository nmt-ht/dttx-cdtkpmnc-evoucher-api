using AutoMapper;
using eVoucher.Domain.Models;
using eVoucher.Infrastructure.Reposistories;

namespace eVoucher.Service.Serivces
{
    public class CampaignService : ICampaignService
    {
        private readonly IDomainRepository _domainRepository;
        private readonly IMapper _mapper;

        public CampaignService(IDomainRepository domainRepository, IMapper mapper)
        {
            _domainRepository = domainRepository;
            _mapper = mapper;
        }

        public Campaign GetCampaignById(Guid id)
        {
            var campaign = _domainRepository.GetOne<Campaign>(c => c.Id == id);
            return campaign;
        }
    }
}
