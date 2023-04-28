using eVoucherApi.Models;

namespace eVoucherApi.Commands.Accounts
{
    public class AccountQueries : IAccountQueries
    {
        private string queriesConnectionString;

        public AccountQueries(string queriesConnectionString)
        {
            this.queriesConnectionString = queriesConnectionString;
        }

        public async Task<IList<Account>> GetAccounts()
        {
            // Connect to database to get data
            return new List<Account>();
        }
    }
}
