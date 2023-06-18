using AutoMapper;
using eVoucher.Domain.Models;
using eVoucher.Infrastructure.Reposistories;
using eVoucher.Service.Dtos;
namespace eVoucher.Service.Services
{
    public class ReportService:IReportService
    {
        private readonly IDomainRepository _domainRepository;
        private readonly IMapper _mapper;

        public ReportService(IDomainRepository domainRepository, IMapper mapper)
        {
            _domainRepository = domainRepository;
            _mapper = mapper;
        }

        public async Task<ReportDto> GetAllCampaigns(Guid id)
        {
            var report = _domainRepository.GetOne<Campaign>(c => c.Id == id);
            return _mapper.Map<Campaign, ReportDto>(report);
        }
    }
}
