using AlDS.Coursework.Board.RelatedTablesModel;
using AlDS.Coursework.WebApplicationTest.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlDS.Coursework.WebApplicationTest.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        public ApplicationDbContext _dbContext;

        public PersonController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(_dbContext);
        }
    }
}
