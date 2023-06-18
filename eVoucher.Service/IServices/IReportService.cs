using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;

namespace eVoucher.Service.Services
{
    public interface IReportService
    {
        Task<ReportDto> GetAllCampaigns(Guid id);
    }
}
