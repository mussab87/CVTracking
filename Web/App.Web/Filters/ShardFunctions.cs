using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace App.Web.Filters { }
public static class ShardFunctions
{
    public static async Task<ApplicationUser> GetLoggedInUserAsync(UserManager<ApplicationUser> userManager, ClaimsPrincipal user)
    {
        return await userManager.GetUserAsync(user);
    }

    #region Get All Controller Action
    public static List<Claim> GetAllControllerActionsUpdated()
    {
        Assembly asm = Assembly.GetExecutingAssembly();

        var controlleractionlist = asm.GetTypes()
            .Where(type => typeof(Controller).IsAssignableFrom(type))
            .SelectMany(type =>
                type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
            .Where(m => !m.GetCustomAttributes(typeof(CompilerGeneratedAttribute),
                true).Any())
            .Select(x => new
            {
                Controller = x.DeclaringType.Name,
                Action = x.Name,
                ReturnType = x.ReturnType.Name,
                Attributes = string.Join(",",
                    x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", "")))
            })
            .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();

        var AllClaims = new List<Claim>();

        var query = controlleractionlist.GroupBy(x => x.Action).Select(y => y.FirstOrDefault());
        foreach (var item in query)
        {
            var ClaimName = "Permission-" + item.Action; //+ "-" + item.Controller;
            var claim = new Claim(ClaimName, ClaimName);
            AllClaims.Add(claim);
        }
        return AllClaims;
    }
    #endregion
}

