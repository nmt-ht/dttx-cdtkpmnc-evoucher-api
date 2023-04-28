using eVoucherApi.Models;

namespace eVoucherApi.Commands.Accounts
{
    public interface IAccountQueries
    {
        Task<IList<Account>> GetAccounts();
    }
}
