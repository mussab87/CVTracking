
using Microsoft.AspNetCore.Authorization;

namespace App.Application.Contracts.UserSecurity.Permissions { }

public class AuthorizePermissionAttribute : AuthorizeAttribute
{
    public AuthorizePermissionAttribute(string permissionName)
    {
        Policy = $"{AuthorizePermissionConstants.PolicyPrefix}{permissionName}";
    }
}

