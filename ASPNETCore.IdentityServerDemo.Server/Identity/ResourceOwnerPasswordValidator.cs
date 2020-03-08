using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASPNETCore.IdentityServerDemo.Server.Identity
{
    internal class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        
        public ResourceOwnerPasswordValidator()
        {
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = context.UserName;
            //custom user verification
            //you can use the Asp.NET Identity UserManager too (too look for users in default database)
            if (user != null 
                && user == "bob")
            {
                context.Result = new GrantValidationResult(
                    "ID1",
                    "custom", 
                    new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Name, "Bob Bobby"),
                        new Claim(JwtClaimTypes.Email, "bob@mail.com"),
                        new Claim(JwtClaimTypes.Role,"admin"),
                        new Claim(JwtClaimTypes.WebSite,"github.com")
                    });
            }
            else if (user != null 
                && user == "alice")
            {
                context.Result = new GrantValidationResult(
                    "ID2",
                    "custom",
                    new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Name, "Alice Ally"),
                        new Claim(JwtClaimTypes.Email, "alice@mail.com"),
                        new Claim(JwtClaimTypes.Role,"user"),
                        new Claim(JwtClaimTypes.WebSite,"github.com")
                    });
            }
            else
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant,"invalid custom credential");
            }

            return Task.CompletedTask;
        }
    }
}
