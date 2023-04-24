using Autofac.Extensions.DependencyInjection;

namespace eVoucherApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureAppConfiguration((host, config) =>
                {
                    // add configuration file base on environment
                    // first get environment name
                    string envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                    string settingFile;

                    if (string.IsNullOrEmpty(envName) || envName.ToLower() == "development")
                    {
                        settingFile = "appsettings.json";
                    }
                    else
                    {
                        settingFile = string.Format("appsettings.{0}.json", envName.ToLower());
                    }

                    if (File.Exists(settingFile))
                    {
                        config.AddJsonFile(settingFile, optional: false, reloadOnChange: true);
                    }
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging(builder => {
                    //builder.AddApplicationInsights(opt => opt.TrackExceptionsAsExceptionTelemetry = false);
                });
    }
}
