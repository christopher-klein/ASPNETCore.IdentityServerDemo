using IdentityModel;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.IdentityServerDemo.Server.InMemoryData
{
    internal static class ResourceManager
    {
        public static IEnumerable<ApiResource> Apis = new List<ApiResource>
            {
                new ApiResource("app.api.weather",
                    "Weather API", new [] 
                    {
                        JwtClaimTypes.Name, 
                        JwtClaimTypes.Email, 
                        JwtClaimTypes.Role, 
                        JwtClaimTypes.WebSite
                    })
            };
    }
}
