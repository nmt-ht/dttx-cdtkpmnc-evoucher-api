using Autofac;

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
            //builder.Register(c => new BlogQueries(QueriesConnectionString)).As<IBlogQueries>().InstancePerLifetimeScope();
        }
    }
}
