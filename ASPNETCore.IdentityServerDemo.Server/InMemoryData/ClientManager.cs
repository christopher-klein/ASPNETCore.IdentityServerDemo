using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.IdentityServerDemo.Server.InMemoryData
{
    internal static class ClientManager
    {
        public static IEnumerable<Client> Clients = new List<Client>
            {
                    new Client
                    {
                         ClientName = "Some Process",
                         ClientId = "app1_machine_to_machine",
                         AllowedGrantTypes = GrantTypes.ClientCredentials,
                         ClientSecrets = { new Secret("verysecret".Sha256()) },
                         AllowedScopes = { "app.api.weather" }
                    },
                    new Client
                    {
                        ClientName = "WebApp Client",
                        ClientId = "app1_user_auth",
                        ClientSecrets = new [] { new Secret("secret".Sha256())  },
                        AllowedScopes = new [] { "app.api.weather"},
                        AllowedGrantTypes = GrantTypes.ResourceOwnerPassword

                    }
            };
    }
}
