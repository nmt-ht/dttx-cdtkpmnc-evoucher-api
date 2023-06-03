using AutoMapper;
using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;

namespace eVoucher.Service.AutoMappings
{
    public class eVourcherProfile : Profile
    {
        public eVourcherProfile()
        {
            CreateMap<UserDto, User>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
               .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
               .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.EmailAddress))
               .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
               .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
               .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
               .ForMember(dest => dest.Addresses, opt => opt.Ignore())
               .ForMember(dest => dest.UserGroups, opt => opt.Ignore());

            CreateMap<AddressDto, Address>()
                //.ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore());

            CreateMap<Address, AddressDto>();

            CreateMap<UserGroupDto, UserGroup>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.EmailAddress))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses))
                .ForMember(dest => dest.UserGroups, opt => opt.MapFrom(src => src.UserGroups));

            CreateMap<Campaign, CampaignDto>()
                .ForMember(dto => dto.ModifiedBy, opt => opt.MapFrom(e => e.ModifiedBy != null ? e.ModifiedBy.Id : Guid.Empty))
                .ForMember(dto => dto.CreatedBy, opt => opt.MapFrom(e => e.CreatedBy != null ? e.CreatedBy.Id : Guid.Empty));
            CreateMap<Partner, PartnerDto>();
            
            CreateMap<CampaignDto, Campaign>()
                .ForMember(dto => dto.ModifiedBy, opt => opt.Ignore())
                .ForMember(dto => dto.CreatedBy, opt => opt.Ignore());
            CreateMap<PartnerDto, Partner>();

            CreateMap<Game, GameDto>()
                .ForMember(dto => dto.ModifiedBy, opt => opt.MapFrom(e => e.ModifiedBy != null ? e.ModifiedBy.Id : Guid.Empty))
                .ForMember(dto => dto.CreatedBy, opt => opt.MapFrom(e => e.CreatedBy != null ? e.CreatedBy.Id : Guid.Empty));

            CreateMap<GameDto, Game>()
                .ForMember(dto => dto.ModifiedBy, opt => opt.Ignore())
                .ForMember(dto => dto.CreatedBy, opt => opt.Ignore());

            CreateMap<CampaignGame, CampaignGameDto>();
            CreateMap<CampaignGameDto, CampaignGame>();

        }
    }
}
