using Autofac;
using eVoucherApi.Commands.Accounts;

namespace eVoucherApi.Infrastructure.AutofacModules
{
    public class ApplicationModule : Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(IConfiguration configuration)
        {
            QueriesConnectionString = configuration["ConnectionString"];
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new AccountQueries(QueriesConnectionString)).As<IAccountQueries>().InstancePerLifetimeScope();
        }
    }
}
