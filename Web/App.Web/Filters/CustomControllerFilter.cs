using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace App.Web.Filters { }
public class CustomControllerFilter : IActionFilter
{
    private readonly string[] _controllerNames;
    public CustomControllerFilter(string[] controllerNames)
    {
        _controllerNames = controllerNames;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Check if the current controller name is in the specified list of controllers
        if (Array.IndexOf(_controllerNames, context.Controller.GetType().Name) != -1)
        {
            // Check if the session exists
            if (context.HttpContext.Session.GetObject<RootCompanyDto>("RootCompany") is null)
            {
                // Redirect to login page if session does not exist
                context.Result = new RedirectToActionResult("Logout", "Account", null);
            }
            //check foreignAgentController
            if (context.Controller.GetType().Name == "ForeignAgentController")
            {
                if (context.HttpContext.Session.GetObject<RootCompanyDto>("ForeignAgent") is null)
                {
                    // Redirect to login page if session does not exist
                    context.Result = new RedirectToActionResult("Logout", "Account", null);
                }
            }

        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // Do nothing
    }
}

