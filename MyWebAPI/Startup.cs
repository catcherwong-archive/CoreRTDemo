namespace MyWebAPI
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ApplicationParts;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using MyLib;
    using MyLib.Data;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var applicationPartManager = new ApplicationPartManager();
            applicationPartManager.ApplicationParts.Add(new AssemblyPart(typeof(Startup).Assembly));
            services.Add(new ServiceDescriptor(typeof(ApplicationPartManager), applicationPartManager));

            // var model = new AppSettingModel();
            // // Bind requrires NuGet package
            // // Microsoft.Extensions.Configuration.Binder
            // Configuration.GetSection("App").Bind(model);
            // services.AddSingleton(model);
         
            // services.Configure<AppSettingModel>(Configuration.GetSection("App"));
            // services.AddScoped<IDataService, DataService>();

            services.AddMvcCore().AddJsonFormatters().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
