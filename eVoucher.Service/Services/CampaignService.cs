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
                var campaign = _domainRepository.GetOne<Campaign>(u => u.Id == id);

                if (campaign is not null) // delete 
                {
                    _domainRepository.Remove(campaign, true);
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
                var campaign = _domainRepository.GetOne<Campaign>(u => u.Id == CampaignDto.Id);
                var createdBy = _domainRepository.GetOne<User>(u => u.Id == CampaignDto.CreatedBy);

                if (campaign is not null) // update
                {
                    campaign = _mapper.Map<Campaign>(CampaignDto);
                    _domainRepository.Update(campaign, true);
                    return true;
                }// add
                else
                {
                    campaign = _mapper.Map<Campaign>(CampaignDto);
                    campaign.CreatedBy = createdBy;
                    campaign.ModifiedBy = createdBy;
                    campaign.CreatedDate = DateTime.Now;
                    campaign.ModifiedDate = DateTime.Now;
                    campaign.IsDeleted = false;
                    _domainRepository.Add(campaign, true);
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
