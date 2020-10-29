using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Globomantics.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Globomantics
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton<IConferenceService, ConferenceMemoryService>();
            services.AddSingleton<IProposalService, ProposalMemoryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            //force redirection to https tls
            //app.UseHttpsRedirection();
            
            //Use authentication before endpoints and routing.
            // app.UseAuthentication();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //Specifies routing using the Routes table.
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Conference}/{action=Index}/{id?}");
                
                //For attribute routing in controllers and actions use the following
                //endpoints.MapControllers();

                
            });
        }
    }
}