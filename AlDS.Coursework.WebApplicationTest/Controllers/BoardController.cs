using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlDS.Coursework.WebApplicationTest.Data;
using Microsoft.AspNetCore.Authorization;
using AlDS.Coursework.Board.RelatedTablesModel;

namespace AlDS.Coursework.WebApplicationTest.Controllers
{
    [Authorize]
    public class BoardController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BoardController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            if (id == null || _context.Board == null)
            {
                return NotFound();
            }
            var peoplesId = _context.UserBoard
                .Where(x => x.BoardId == id)
                .Select(x=>x.UserId);

            var emailPeoples = new List<string>();
            foreach (var people in peoplesId)
            {
                emailPeoples.Add(_context.User.First(x => x.Id == people).Email);
            }

            ViewData["emailPeoples"] = emailPeoples;


            var board = await _context.Board
                .FirstOrDefaultAsync(m => m.BoardId == id);
            if (board == null)
            {
                return NotFound();
            }

            var cards = await _context.Card
                .Where(x => x.BoardId == board.BoardId)
                .ToListAsync();

            ViewData["Creator"] = _context.User.First(x => x.Id == board.UserId).Email;

            foreach (var elem in board.Cards)
            {
                var notes = await _context.Note
                    .Where(x => x.CardId == elem.CardId)
                    .ToListAsync();
            }

            return View(board);
        }

        // GET: Board/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Board/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        public async Task<IActionResult> Create([Bind("UserId,Space,Title,Description")] Board.BoardModel.Board board)
        {
            var userId = await _context.User.FirstAsync(x => x.Email == board.UserId);

            var newBoard = new Board.BoardModel.Board()
            {
                UserId = userId.Id,
                Title = board.Title,
                Description = board.Description,
                Space = board.Space,
            };
            var newUserBoard = new Board.RelatedTablesModel.UserBoard()
            {
                User = userId,
                Board = newBoard,
                UserId = userId.Id,
                BoardId = newBoard.BoardId,
                Key = new String(userId.Id + newBoard.BoardId)
            };
            
            if (userId == null)
                return View(board);

            await _context.Board.AddAsync(newBoard);
            await _context.UserBoard.AddAsync(newUserBoard);

            await _context.SaveChangesAsync();
            return Redirect("../board/Index/" + newBoard.BoardId);
        }

        /*
                    if (ModelState.IsValid)
            {
                _context.Add(board);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
         */


        // GET: Board/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Board == null)
            {
                return NotFound();
            }

            var board = await _context.Board.FindAsync(id);
            if (board == null)
            {
                return NotFound();
            }
            return View(board);
        }

        // POST: Board/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(string id, [Bind("Space,Title,Description")] Board.BoardModel.Board board)
        {
            var updBoard = await _context.Board.FirstAsync(x => x.BoardId == id);
            
            updBoard.Space = board.Space;
            if (board.Title != null)
                updBoard.Title = board.Title;
            if (board.Description !=  null)
                updBoard.Description = board.Description;
            updBoard.DateUpdated = DateTime.UtcNow;

            //_context.Update(updBoard);
            _context.SaveChanges();

            return Redirect("../board/Index/" + updBoard.BoardId);
        }

        public async Task<IActionResult> AddPerson(string email, string boardId)
        {
            var id = await _context.User
                .FirstAsync(x=>x.Email == email);

            var board = await _context.UserBoard
                .FirstOrDefaultAsync(x => x.BoardId == boardId);

            if(board == null)
            {
                return NotFound();
            }

            await _context.UserBoard.AddAsync(new UserBoard
                {
                    BoardId = boardId,
                    UserId = id.Id,
                });
            _context.SaveChanges();
            return Redirect("../board/Index/" + boardId);
        }

        public async Task<IActionResult> DeletePerson(string email, string boardId)
        {
            var id = await _context.User
                .FirstAsync(x => x.Email == email);
            var board = await _context.UserBoard
                .FirstOrDefaultAsync(x => x.BoardId == boardId);

            if (board == null)
            {
                return NotFound();
            }

            var elem = await _context.UserBoard
                .FirstAsync(x=>x.BoardId == boardId && x.UserId == id.Id);

            _context.UserBoard.Remove(elem);
            _context.SaveChanges();

            return Redirect("../board/Index/" + boardId);
        }


        // GET: Board/Delete/5
        public async Task<IActionResult> Delete(string id, string email)
        {
            if (id == null || _context.Board == null)
            {
                return NotFound();
            }

            var board = await _context.Board
                .FirstOrDefaultAsync(m => m.BoardId == id);
            if (board == null)
            {
                return NotFound();
            }

            _context.UserBoard
                .RemoveRange(_context.UserBoard
                .Where(x=>x.BoardId==board.BoardId));

            _context.Board.Remove(board);

            await _context.SaveChangesAsync();

            return Redirect("../../Person/Index/?email=" + email);
        }

        // POST: Board/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Board == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Board'  is null.");
            }
            var board = await _context.Board.FindAsync(id);
            if (board != null)
            {
                _context.Board.Remove(board);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoardExists(string id)
        {
          return _context.Board.Any(e => e.BoardId == id);
        }



        public async Task<IActionResult> Test(string id)
        {
            var board = await _context.Board
                .FirstOrDefaultAsync(m => m.BoardId == id);

            var cards = await _context.Card
                .Where(x => x.BoardId == board.BoardId)
                .ToListAsync();

            foreach (var elem in board.Cards)
            {
                var notes = await _context.Note
                    .Where(x => x.CardId == elem.CardId)
                    .ToListAsync();
            }

            return View(board);
        }

    }
}

/*
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(board);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoardExists(board.BoardId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }
 */

