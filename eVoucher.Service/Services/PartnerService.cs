﻿using AutoMapper;
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

        public Partner GetPartnerById(Guid id)
        {
            var Partner = _domainRepository.GetOne<Partner>(c => c.Id == id);
            return Partner;
        }

        public async Task<bool> DeletePartner(Guid id)
        {
            try
            {
                var Partner = _domainRepository.GetOne<Partner>(u => u.Id == id);

                if (Partner is not null) // delete 
                {
                    _domainRepository.Remove(Partner, true);
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

        public async Task<bool> UpdatePartner(PartnerDto PartnerDto)
        {
            try
            {
                var Partner = _domainRepository.GetOne<Partner>(u => u.Id == PartnerDto.Id);
                var guid = new Guid("BEFA0A81-89DB-46B4-83C0-2E43FDFF1B55");


                if (Partner is not null) // update
                {
                    Partner = _mapper.Map<Partner>(PartnerDto);
                    Partner.User = _domainRepository.GetOne<User>(u => u.Id == guid);
                    _domainRepository.Update(Partner, true);
                    return true;
                }// add
                else
                {
                    Partner = _mapper.Map<Partner>(PartnerDto);
                    Partner.User = _domainRepository.GetOne<User>(u => u.Id == guid);
                    _domainRepository.Add(Partner, true);
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
