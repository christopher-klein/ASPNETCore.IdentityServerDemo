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
                         ClientName = "Client Application2",
                         ClientId = "3X=nNv?Sgu$S",
                         AllowedGrantTypes = GrantTypes.ClientCredentials,
                         ClientSecrets = { new Secret("1554db43-3015-47a8-a748-55bd76b6af48".Sha256()) },
                         AllowedScopes = { "app.api.weather" }
                    },
                    new Client
                    {
                        ClientId = "x12345",
                        ClientName = "WbApp Client",
                        ClientSecrets = new [] { new Secret("secret".Sha256())  },
                        AllowedScopes = new [] { "app.api.weather", "roles"},
                        AllowedGrantTypes = GrantTypes.ResourceOwnerPassword

                    }
            };
    }
}
