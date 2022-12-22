using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlDS.Coursework.WebApplicationTest.Controllers
{
    [AllowAnonymous]

    public class Login : Controller
    {
            [Route("Login/{returnUrl?}")]
            public IActionResult Index(string returnUrl = null)
            {
                ViewData["ReturnUrl"] = returnUrl;

                return View();
            }


        }

}
