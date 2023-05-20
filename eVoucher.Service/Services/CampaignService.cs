using AutoMapper;
using eVoucher.Domain.Models;
using eVoucher.Infrastructure.Reposistories;
using eVoucher.Service.Dtos;

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

        public async Task<bool> DeleteCampaign(Guid id)
        {
            try
            {
                var Campaign = _domainRepository.GetOne<Campaign>(u => u.Id == id);

                if (Campaign is not null) // delete 
                {
                    _domainRepository.Remove(Campaign, true);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateCampaign(CampaignDto CampaignDto)
        {
            try
            {
                var Campaign = _domainRepository.GetOne<Campaign>(u => u.Id == CampaignDto.Id);

                if (Campaign is not null) // update
                {
                    Campaign = _mapper.Map<Campaign>(CampaignDto);
                    _domainRepository.Update(Campaign, true);
                    return true;
                }// add
                else
                {
                    Campaign = _mapper.Map<Campaign>(CampaignDto);
                    _domainRepository.Add(Campaign, true);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
