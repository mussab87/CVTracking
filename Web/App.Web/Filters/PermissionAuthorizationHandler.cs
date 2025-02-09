﻿using Microsoft.AspNetCore.Authorization;

namespace App.Web { }

public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    public PermissionAuthorizationHandler()
    {

    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        if (context.User == null)
            return;

        //var canAccess = context.User.Claims.Any(c => c.Type == "Permission" && c.Value == requirement.Permission && c.Issuer == "LOCAL AUTHORITY");
        var canAccess = context.User.Claims.Any(c => c.Value == requirement.Permission && c.Issuer == "LOCAL AUTHORITY");

        if (canAccess)
        {
            context.Succeed(requirement);
            return;
        }
    }
}

