
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace App.Application.Contracts.UserSecurity.TagHelpers { }
[HtmlTargetElement(Attributes = "asp-authorize-permission")]
public class AuthorizePermissionTagHelper : TagHelper, IAuthorizeData
{
    private readonly IAuthorizationPolicyProvider _policyProvider;
    private readonly IPolicyEvaluator _policyEvaluator;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthorizePermissionTagHelper(IHttpContextAccessor httpContextAccessor, IAuthorizationPolicyProvider policyProvider, IPolicyEvaluator policyEvaluator)
    {
        _httpContextAccessor = httpContextAccessor;
        _policyProvider = policyProvider;
        _policyEvaluator = policyEvaluator;
    }

    [HtmlAttributeName("asp-permission")]
    public string Policy { get; set; }
    public string Roles { get; set; }
    public string AuthenticationSchemes { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        Policy = $"{AuthorizePermissionConstants.PolicyPrefix}{Policy}";

        var policy = await AuthorizationPolicy.CombineAsync(_policyProvider, new[] { this });

        var authenticateResult = await _policyEvaluator.AuthenticateAsync(policy, _httpContextAccessor.HttpContext);

        var authorizeResult = await _policyEvaluator.AuthorizeAsync(policy, authenticateResult, _httpContextAccessor.HttpContext, null);

        if (!authorizeResult.Succeeded)
        {
            output.SuppressOutput();
        }

        if (output.Attributes.TryGetAttribute("asp-authorize-permission", out TagHelperAttribute attribute))
        {
            output.Attributes.Remove(attribute);
        }
    }
}

