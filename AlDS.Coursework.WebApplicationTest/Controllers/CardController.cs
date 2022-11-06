using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlDS.Coursework.Board.BoardModel;
using AlDS.Coursework.WebApplicationTest.Data;
using Microsoft.AspNetCore.Authorization;

namespace AlDS.Coursework.WebApplicationTest.Controllers
{
    [Authorize]
    public class CardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create(string BoardId)
        {
            ViewData["Message"] = BoardId;
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([Bind("CreatorId,BoardId,Title,Description")] Card card)
        {
            var user = await _context.User
                .FirstOrDefaultAsync(x => x.Email == card.CreatorId);

            if (user == null)
                return NotFound();

            card.CreatorId = user.Id;
            _context.Add(card);
            await _context.SaveChangesAsync();
            return Redirect("../Board/Info/" + card.BoardId);
 
        }

        // GET: Card/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Card == null)
            {
                return NotFound();
            }

            var card = await _context.Card.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }
            ViewData["BoardId"] = new SelectList(_context.Board, "BoardId", "BoardId", card.BoardId);
            return View(card);
        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(string id, [Bind("CardId,CreatorId,BoardId,Title,Description")] Card card)
        {
            var updCard = await _context.Card.FirstAsync(x => x.CardId == id);

            updCard.Title = card.Title;
            updCard.Description = card.Description;
            updCard.DateUpdated = DateTime.UtcNow;

            _context.SaveChanges();

            return Redirect("../../Board/Info/" + updCard.BoardId);
        }


        public async Task<IActionResult> Delete(string id, string BoardId)
        {
            if (id == null || _context.Card == null)
            {
                return NotFound();
            }

            var card = await _context.Card
                .FirstOrDefaultAsync(m => m.CardId == id);
            if (card == null)
            {
                return NotFound();
            }

            _context.Card.Remove(card);
            _context.SaveChanges();

            return Redirect("../../Board/Info/" + BoardId);
        }

        // POST: Card/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Card == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Card'  is null.");
            }
            var card = await _context.Card.FindAsync(id);
            if (card != null)
            {
                _context.Card.Remove(card);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardExists(string id)
        {
          return _context.Card.Any(e => e.CardId == id);
        }
    }
}
