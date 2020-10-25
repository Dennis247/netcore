﻿using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityDemo.AuthorizationRequirement
{
    public class CustomRequireClaim : IAuthorizationRequirement
    {
      public string ClaimType { get; }

        public CustomRequireClaim(string claimType)
        {
            ClaimType = claimType;
        }
    }

    public class CustomRequireClaimHandler : AuthorizationHandler<CustomRequireClaim>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomRequireClaim requirement)
        {
          var hasClaims =  context.User.Claims.Any(x => x.Type == requirement.ClaimType);
            if (hasClaims)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;

        }
    }

    public static class AuthorizationPolicyBuilderExtensions
    {
        public static AuthorizationPolicyBuilder RequireCustomClaim(this AuthorizationPolicyBuilder builder,string claimType)
        {
           builder .AddRequirements(new CustomRequireClaim(claimType));
            return builder;
        }
    }
}
