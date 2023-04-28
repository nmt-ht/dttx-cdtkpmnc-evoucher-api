using System.Linq.Expressions;

namespace eVoucher.Infrastructure.Reposistories
{
    public class DomainRepository : Repository, IDomainRepository
    {
        public DomainRepository(IRepositoryFactory repositoryFactory) : base(repositoryFactory)
        {

        }

        public T GetOne<T>(Expression<Func<T, bool>> filter)
        {
            return Get<T>(filter).FirstOrDefault();
        }
    }
}
