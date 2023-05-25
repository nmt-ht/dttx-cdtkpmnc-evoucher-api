using AutoMapper;
using eVoucher.Domain.Models;
using eVoucher.Infrastructure.Reposistories;
using eVoucher.Service.Dtos;
using eVoucherApi.domain.Models;

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

        public async Task<bool> EditGame(GameDto gameDto)
        {
            if (gameDto is not null)
            {
                var game = _domainRepository.GetOne<Game>(ad => ad.Id == gameDto.Id);
                game.Name = gameDto.Name;
                game.Description = gameDto.Description;
                _domainRepository.Update(game);
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteGame(Guid id)
        {
            try
            {
                var game = _domainRepository.GetOne<Game>(u => u.Id == id);

                if (game is not null) // delete 
                {
                    _domainRepository.Remove(game, true);
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
    } 
}
