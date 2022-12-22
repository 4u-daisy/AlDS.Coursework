using Microsoft.AspNetCore.Mvc;

namespace AlDS.Coursework.WebApplicationTest.Controllers
{
    public class Register : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
