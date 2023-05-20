using AutoMapper;
using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;

namespace eVoucher.Service.AutoMappings
{
    public class eVourcherProfile : Profile
    {
        public eVourcherProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<Campaign, CampaignDto>();
            CreateMap<Partner, PartnerDto>();
            CreateMap<UserDto, User>();
            CreateMap<AddressDto, Address>();
            CreateMap<CampaignDto, Campaign>();
            CreateMap<PartnerDto, Partner>();
        }
    }
}
