using eVoucher.Infrastructure.Maps;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using NHibernate;

namespace eVoucher.Infrastructure
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly IConfiguration _configuration;
        public RepositoryFactory(IConfiguration configuration)
        {
            _configuration = configuration;

            var dbConfig = MsSqlConfiguration.MsSql2008.ConnectionString(_configuration["ConnectionString"]).AdoNetBatchSize(10);
            NHibernate.Cfg.Configuration config = Fluently.Configure()
                .Database(dbConfig)
                .Mappings(cfg =>
                {
                    cfg.FluentMappings.AddFromAssemblyOf<UserMap>();
                })
                .BuildConfiguration();

            _sessionFactory = config.BuildSessionFactory();
        }

        public ISession CreateSession()
        {
            return _sessionFactory.OpenSession();
        }

        #region IDisposable Members
        private bool _disposed = false;

        public void Dispose()
        {
            if (!this._disposed)
            {
                _sessionFactory.Dispose();
                this._disposed = true;
            }
        }
        #endregion 
    }
}
