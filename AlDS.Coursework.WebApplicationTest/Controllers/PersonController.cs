using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlDS.Coursework.WebApplicationTest.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
