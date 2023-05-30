using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    [Authorize(Roles.Admin)]
    public class RootCompanyController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult test()
        {
            return View();
        }
    }
}
