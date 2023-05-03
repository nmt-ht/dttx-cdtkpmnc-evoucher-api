using eVoucher.Service.Dtos;

namespace eVoucher.Service.Serivces
{
    public interface IUserService
    {
        Task<bool> UpdateUser(CreateUserDto createUserDto);
        Task<bool> DeleteUser(Guid id);
    }
}
