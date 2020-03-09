using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCore.IdentityServerDemo.Server.Identity;
using ASPNETCore.IdentityServerDemo.Server.InMemoryData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ASPNETCore.IdentityServerDemo.Server
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServer()
                    .AddDeveloperSigningCredential() // do not use in production
                    .AddInMemoryApiResources(ResourceManager.Apis)
                    .AddInMemoryClients(ClientManager.Clients)
                    .AddInMemoryIdentityResources(IdentityManager.IdentityResources)
                    .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
                    .AddProfileService<ProfileService>();

            // Define Clients, ApiResources and IdentityResources in appsettings.json when running in 
            // production so you can easily manage other client authentications
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // --> use identity server here <--
            app.UseIdentityServer();

            app.UseRouting();

            // used to show OpenID configuration when getting base url
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    context.Response.Redirect("/.well-known/openid-configuration");
                });
            });
        }
    }
}
