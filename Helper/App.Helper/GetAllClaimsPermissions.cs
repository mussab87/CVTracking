using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace App.Helper { }

public static class GetAllClaimsPermissions
{
    #region Get All Controller Action
    public static List<Claim> GetAllControllerActionsUpdated()
    {
        Assembly asm = AppDomain.CurrentDomain.GetAssemblies()[1]; //Assembly.GetExecutingAssembly();

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
            if (item.Controller == "RootCompanyController")
            {
                var ClaimNameRoot = "RootCompany" + "-" + item.Action; //+ "-" + item.Controller;
                var claimRoot = new Claim(ClaimNameRoot, ClaimNameRoot);
                AllClaims.Add(claimRoot);

                continue;
            }

            var ClaimName = "Permission-" + item.Action; //+ "-" + item.Controller;
            var claim = new Claim(ClaimName, ClaimName);
            AllClaims.Add(claim);
        }
        return AllClaims;
    }
    #endregion
}

