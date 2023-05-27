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
            CreateMap<Campaign, CampaignDto>()
                .ForMember(dto => dto.ModifiedBy, opt => opt.MapFrom(e => e.ModifiedBy != null ? e.ModifiedBy.Id : Guid.Empty))
                .ForMember(dto => dto.CreatedBy, opt => opt.MapFrom(e => e.CreatedBy != null ? e.CreatedBy.Id : Guid.Empty));
            CreateMap<Partner, PartnerDto>();            
            CreateMap<UserDto, User>()
                .ForMember(dto => dto.Addresses, opt => opt.Ignore());
            CreateMap<AddressDto, Address>();
            CreateMap<CampaignDto, Campaign>()
                .ForMember(dto => dto.ModifiedBy, opt => opt.Ignore())
                .ForMember(dto => dto.CreatedBy, opt => opt.Ignore());
            CreateMap<PartnerDto, Partner>();
        }
    }
}
