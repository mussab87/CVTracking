using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace App.Application.Contracts.UserSecurity.Permissions { }

public class PermissionAuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
{
    public PermissionAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options) : base(options)
    {
    }

    public override async Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
    {
        if (!policyName.StartsWith(AuthorizePermissionConstants.PolicyPrefix, StringComparison.OrdinalIgnoreCase))
        {
            return await base.GetPolicyAsync(policyName);
        }

        var claimName = policyName.Substring(AuthorizePermissionConstants.PolicyPrefix.Length);

        var policy = new AuthorizationPolicyBuilder()
            .RequireClaim(AuthorizePermissionConstants.ClaimType, claimName)
            .Build();

        return policy;
    }
}

