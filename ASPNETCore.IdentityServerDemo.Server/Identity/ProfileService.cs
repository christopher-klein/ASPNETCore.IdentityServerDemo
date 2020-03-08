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
            var id = context.Client.ClientId;
            var userId = context.Subject.Claims.FirstOrDefault(x => x.Type == "sub");

            //get data by userid
            context.IssuedClaims = context.Subject.Claims.Where(x => context.RequestedClaimTypes.Contains(x.Type)).ToList();
          
            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }
    }
}
