using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlDS.Coursework.Board.BoardModel;
using AlDS.Coursework.WebApplicationTest.Data;
using Microsoft.AspNetCore.Authorization;

namespace AlDS.Coursework.WebApplicationTest.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NoteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string id, string boardId="")
        {
            ViewData["id"] = boardId;
            var elem = await _context.Note
                .FirstOrDefaultAsync(x=>x.NoteId == id);

            return View(elem);
        }

        // GET: Note/Create
        public IActionResult Create()
        {
            ViewData["CardId"] = new SelectList(_context.Card, "CardId", "CardId");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("CreatorId,CardId,Title,Description,Text,Comment")] Note note, string BoardId = "")
        {
            if (_context.Card.FirstOrDefaultAsync(x=>x.CardId == note.CardId) == null)
            {
                return NotFound();
            }
            var userId = _context.User.First(x => x.Email == note.CreatorId);
            var newNote = new Note()
            {
                CreatorId = userId.Id,
                CardId = note.CardId,
                Card = note.Card,
                Title = note.Title,
                Description = note.Description,
                Text = note.Text,
                Comment = note.Comment,
                DateCreated = DateTime.UtcNow,
            };

            _context.Note.Add(newNote);
            _context.SaveChanges();

            if (BoardId == "")
                return View(note);

            return Redirect("../../Board/Index/" + BoardId);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Note == null)
            {
                return NotFound();
            }

            var note = await _context.Note.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }
            ViewData["CardId"] = new SelectList(_context.Card, "CardId", "CardId", note.CardId);
            return View(note);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(string id, [Bind("NoteId,CreatorId,CardId,Title,Description,Text,Comment")] Note note)
        {
            //if (id != note.NoteId)
            //{
            //    return NotFound();
            //}

            var updNote = _context.Note
                .FirstOrDefault(x => x.NoteId == id);

            if (updNote == null)
                return NotFound();

            updNote.Text = note.Text;
            updNote.Description = note.Description;
            updNote.Comment = note.Comment;
            updNote.Title = note.Title;
            updNote.DateUpdated = DateTime.UtcNow;

            _context.SaveChanges();

            return Redirect("Index/"+id);
        }

        // GET: Note/Delete/5
        public async Task<IActionResult> Delete(string id, string BoardId)
        {
            if (id == null || _context.Note == null)
            {
                return NotFound();
            }

            var note = _context.Note
                .FirstOrDefault(m => m.NoteId == id);
            if (note == null)
            {
                return NotFound();
            }

            _context.Note.Remove(note);
            _context.SaveChanges();

            return Redirect("../../Board/Info" + BoardId);
        }

        // POST: Note/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Note == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Note'  is null.");
            }
            var note = await _context.Note.FindAsync(id);
            if (note != null)
            {
                _context.Note.Remove(note);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoteExists(string id)
        {
          return _context.Note.Any(e => e.NoteId == id);
        }
    }
}
