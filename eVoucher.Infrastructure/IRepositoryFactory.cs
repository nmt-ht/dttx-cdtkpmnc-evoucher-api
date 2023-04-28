using NHibernate;

namespace eVoucher.Infrastructure
{
    public interface IRepositoryFactory : IDisposable
    {
        ISession CreateSession();
    }
}
