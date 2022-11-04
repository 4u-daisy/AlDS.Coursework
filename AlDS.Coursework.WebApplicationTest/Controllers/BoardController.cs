using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlDS.Coursework.Board.BoardModel;
using AlDS.Coursework.WebApplicationTest.Data;

namespace AlDS.Coursework.WebApplicationTest.Controllers
{
    public class BoardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BoardController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Board
        public async Task<IActionResult> Index()
        {
              return View(await _context.Board.ToListAsync());
        }

        public async Task<IActionResult> Info(string id)
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

            return View(board);
        }

        // GET: Board/Details/5
        public async Task<IActionResult> Details(string id)
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
            var tmp = board.UserId;
            var userId = await _context.User.FirstAsync(x => x.Email == tmp);

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
            return Redirect("../board/" + newBoard.BoardId);
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BoardId,UserId,Space,Title,Description,DateCreated,DateUpdated")] Board.BoardModel.Board board)
        {
            if (id != board.BoardId)
            {
                return NotFound();
            }

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
            return View(board);
        }

        // GET: Board/Delete/5
        public async Task<IActionResult> Delete(string id)
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

            return View(board);
        }

        // POST: Board/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
    }
}
