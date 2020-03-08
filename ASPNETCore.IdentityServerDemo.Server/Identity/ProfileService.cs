using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASPNETCore.IdentityServerDemo.Server.Identity
{
    public class ProfileService : IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            // example of getting client id
            var id = context.Client.ClientId;
            
            // sub claim is default for userid when using .net identity manager
            var userId = context.Subject.Claims.FirstOrDefault(x => x.Type == "sub");

            //ajust claims
            context.IssuedClaims = context.Subject.Claims.Where(x => context.RequestedClaimTypes.Contains(x.Type)).ToList();
          
            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            // normally you gotta search your user
            // and determine if he is active or not
            context.IsActive = true;
            return Task.CompletedTask;
        }
    }
}
