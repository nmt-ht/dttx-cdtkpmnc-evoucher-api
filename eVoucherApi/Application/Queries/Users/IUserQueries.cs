using eVoucherApi.Models;

namespace eVoucher.Services.Api.Application.Queries
{
    public interface IUserQueries
    {
        Task<IList<User>> GetUsers(Guid id = default);
        Task<bool> CreateUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(User user);
    }
}
