using LearnDotNetCore.Data;
using LearnDotNetCore.Interfaces;
using LearnDotNetCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LearnDotNetCore
{
    public class Startup
    {
        //Get comfiguration key from appsettings.json The development json overrides the default json, and everything is overriden by 
        // variables in launchsettigs file, the environment one which in turn is overriden by the cli variables
        private IConfiguration _config;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddMvc();
            // services.AddMvcCore(); it adds only the core services, unlike the MVC that adds all the services
            // Inject the service
            services.AddSingleton<IEmployeeRepository,   EmployeeInMemoryRepository>();
                       
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
     
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Inject logger to see how the pipleline works
            // These are middlewares. 
            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions()
                {
                    // The number of lines for source code that will be displayed to show error
                    SourceCodeLineCount = 10
                };
                app.UseDeveloperExceptionPage(developerExceptionPageOptions);
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Error/");
               
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //Authentication here
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
