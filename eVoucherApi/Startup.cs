using Autofac;
using eVoucherApi.Infrastructure.AutofacModules;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace eVoucherApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();
            services.AddOptions();

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddSwaggerGen();

            services.AddApplicationInsightsTelemetry();

            //RegisterErrorHandling(services);
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Register your own things directly with Autofac, like:
            builder.RegisterModule(new ApplicationModule(Configuration));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors(builder => {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });

            app.UseSwagger(s =>
            {
                s.RouteTemplate = "api/swagger/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "EVOUCHER API");
                c.RoutePrefix = "api/swagger";

                c.DefaultModelsExpandDepth(-1);
            });
        }

        //private void RegisterErrorHandling(IServiceCollection services)
        //{
        //    services.AddTransient<IMailing, EmailHandler>();
        //}
    }
}
