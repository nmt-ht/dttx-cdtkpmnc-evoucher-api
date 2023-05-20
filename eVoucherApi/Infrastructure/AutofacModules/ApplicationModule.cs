using Autofac;
using eVoucher.Infrastructure.Reposistories;
using eVoucher.Infrastructure;
using eVoucher.Services.Api.Application.Queries;
using eVoucher.Service.Serivces;

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
            builder.Register(c => new UserQueries(QueriesConnectionString)).As<IUserQueries>().InstancePerLifetimeScope();
            builder.Register(c => new CampaignQueries(QueriesConnectionString)).As<ICampaignQueries>().InstancePerLifetimeScope();
            builder.Register(c => new PartnerQueries(QueriesConnectionString)).As<IPartnerQueries>().InstancePerLifetimeScope();

            // Register Repositories 
            builder.RegisterType<RepositoryFactory>().As<IRepositoryFactory>().SingleInstance();
            builder.RegisterType<DomainRepository>().As<IDomainRepository>().InstancePerLifetimeScope();

            // Register Services
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<CampaignService>().As<ICampaignService>().InstancePerLifetimeScope();
            builder.RegisterType<PartnerService>().As<IPartnerService>().InstancePerLifetimeScope();
        }
    }
}
