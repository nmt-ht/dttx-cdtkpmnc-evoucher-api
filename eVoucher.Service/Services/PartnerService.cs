using AutoMapper;
using eVoucher.Domain.Models;
using eVoucher.Infrastructure.Reposistories;
using eVoucher.Service.Dtos;

namespace eVoucher.Service.Serivces
{
    public class PartnerService : IPartnerService
    {
        private readonly IDomainRepository _domainRepository;
        private readonly IMapper _mapper;

        public PartnerService(IDomainRepository domainRepository, IMapper mapper)
        {
            _domainRepository = domainRepository;
            _mapper = mapper;
        }

        public async Task<PartnerDto> GetPartnerById(Guid id)
        {
            var partner = _domainRepository.GetOne<Partner>(c => c.Id == id);
            return _mapper.Map<Partner, PartnerDto>(partner);
        }

        public async Task<bool> DeletePartner(Guid id)
        {
            try
            {
                var partner = _domainRepository.GetOne<Partner>(u => u.Id == id);

                if (partner is not null) // delete 
                {
                    _domainRepository.Remove(partner, true);
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

        public async Task<bool> UpdatePartner(PartnerDto partnerDto)
        {
            try
            {
                if (partnerDto != null)
                {
                    if (partnerDto.Id != Guid.Empty) // update
                    {
                        var partner = _mapper.Map<PartnerDto, Partner>(partnerDto);
                        partner.User = _domainRepository.GetOne<User>(u => u.Id == partnerDto.User_ID_FK);
                        _domainRepository.Update(partner, true);
                        return true;
                    }// add
                    else
                    {
                        var partner = _mapper.Map<Partner>(partnerDto);
                        partner.User = _domainRepository.GetOne<User>(u => u.Id == partnerDto.User_ID_FK);
                        _domainRepository.Add(partner, true);
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
    }
}
