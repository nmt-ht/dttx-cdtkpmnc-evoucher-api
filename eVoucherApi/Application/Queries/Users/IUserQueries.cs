using eVoucher.Service.Dtos;

namespace eVoucher.Services.Api.Application.Queries
{
    public interface IUserQueries
    {
        Task<IList<UserDto>> GetUsers();
        Task<IList<UserGroupDto>> GetUserGroups();
        Task<IList<UserVoucherDto>> GetUserVouchers(Guid currentUserId);
    }
}
