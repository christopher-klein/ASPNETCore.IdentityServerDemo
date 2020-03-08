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
                new ApiResource {
                    Name = "app.1",
                    DisplayName = "Whatever 1",
                    ApiSecrets = { new Secret("a75a559d-1dab-4c65-9bc0-f8e590cb388d".Sha256()) },
                    
                    Scopes = new List<Scope> {
                        new Scope("app.1.read"),
                        new Scope("app.1.write")
                    }
                },
                new ApiResource("app.api.weather","Weather Apis", new [] { JwtClaimTypes.Name, JwtClaimTypes.Email, JwtClaimTypes.Role, JwtClaimTypes.WebSite})
            };
    }
}
