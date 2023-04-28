using eVoucher.Domain.SeekWork;
using System.Linq.Expressions;

namespace eVoucher.Infrastructure.Reposistories
{
    public interface IDomainRepository : IRepository
    {
        T GetOne<T>(Expression<Func<T, bool>> filter);
    }
}
