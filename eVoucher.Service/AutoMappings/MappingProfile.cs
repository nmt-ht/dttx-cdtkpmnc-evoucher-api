using AutoMapper;
using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;

namespace eVoucher.Service.AutoMappings
{
    public class eVourcherProfile : Profile
    {
        public eVourcherProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dto => dto.Addresses, opt => opt.Ignore());
            CreateMap<Address, AddressDto>();
            CreateMap<Campaign, CampaignDto>();
            CreateMap<Partner, PartnerDto>();
            CreateMap<UserDto, User>()
                .ForMember(dto => dto.Addresses, opt => opt.Ignore());
            CreateMap<AddressDto, Address>();
            CreateMap<CampaignDto, Campaign>();
            CreateMap<PartnerDto, Partner>();
        }
    }
}
