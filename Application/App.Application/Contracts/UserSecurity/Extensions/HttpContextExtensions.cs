using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Security.Claims;

namespace App.Application.Contracts.UserSecurity.Extensions { }

public static class HttpContextExtensions
{
    public static bool IsSignedInUser(this HttpContext context)
    {
        return context.User != null && context.User.Identity != null && context.User.Identity.IsAuthenticated;
    }

    public static bool IsSignedInUser(this ClaimsPrincipal principal)
    {
        return principal.Identity != null && principal.Identity.IsAuthenticated;
    }
}

