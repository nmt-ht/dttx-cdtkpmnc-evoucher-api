using Antlr.Runtime;
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

        public async Task<CampaignDto> GetCampaignById(Guid id)
        {
            var campaign = _domainRepository.GetOne<Campaign>(c => c.Id == id);
            return _mapper.Map<Campaign, CampaignDto>(campaign);
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

        public async Task<bool> UpdateCampaign(CampaignDto campaignDto)
        {
            try
            {
                if (campaignDto is not null)
                {
                    if (campaignDto.Id != Guid.Empty) // update
                    {
                        var createdBy = _domainRepository.GetOne<User>(u => u.Id == campaignDto.CreatedBy);
                        var modifiedBy = _domainRepository.GetOne<User>(u => u.Id == campaignDto.ModifiedBy);
                        var campaign = _mapper.Map<Campaign>(campaignDto);
                        campaign.CreatedBy = createdBy;
                        campaign.ModifiedBy = modifiedBy;
                        campaign.ModifiedDate = DateTime.Now;
                        foreach (CampaignGame campaignGame in campaign.CampaignGames)
                        {
                            campaignGame.Campaign = campaign;
                        }

                        var campaignGameIds = campaign.CampaignGames.Select(x => x.Id).ToList();
                        var campaignGames = _domainRepository.Get<CampaignGame>(x => x.Campaign.Id == campaign.Id && !campaignGameIds.Contains(x.Id)).ToList();
                        foreach (CampaignGame campaignGame in campaignGames)
                        {
                            _domainRepository.Remove(campaignGame);
                        }

                        _domainRepository.AddOrUpdate(campaign, true);
                        return true;
                    }// add
                    else
                    {
                        var createdBy = _domainRepository.GetOne<User>(u => u.Id == campaignDto.CreatedBy);
                        var campaign = _mapper.Map<Campaign>(campaignDto);
                        campaign.CreatedBy = createdBy;
                        campaign.ModifiedBy = createdBy;
                        campaign.CreatedDate = DateTime.Now;
                        campaign.ModifiedDate = DateTime.Now;
                        campaign.IsDeleted = false;

                        foreach (CampaignGame campaignGame in campaign.CampaignGames)
                        {
                            campaignGame.Campaign = campaign;
                        }

                        _domainRepository.Add(campaign, true);
                        return true;
                    }
                }
                return false;
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
                var game = _mapper.Map<Game>(gameDto);
                _domainRepository.Update(game, true);
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
