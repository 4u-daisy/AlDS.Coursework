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

        public IActionResult Index(string email)
        {
            var user = _dbContext.User
                .First(x=>x.Email == email);

            ViewData["Name"] = user.Name;

            var userBoard = _dbContext.UserBoard
                .Where(x => x.UserId == user.Id);

            var boards = new List<Board.BoardModel.Board>();
            foreach (var elem in userBoard)
            {
                boards.Add(_dbContext.Board.First(x => x.BoardId == elem.BoardId));
            }

            return View(boards);
        }
    }
}
