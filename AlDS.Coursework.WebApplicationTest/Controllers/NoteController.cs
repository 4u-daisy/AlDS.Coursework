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
        public async Task<IActionResult> Index(string id)
        {
            var elem = await _context.Note
                .FirstOrDefaultAsync(x=>x.NoteId == id);
            if (elem == null)
            {
                return NotFound();
            }

            var card = await _context.Card
                .FirstAsync(x => x.CardId == elem.CardId);

            var userExecutes = await _context.User
                .FirstAsync(x => x.Id == elem.IdUserExecutes);

            var user = await _context.User
                .FirstAsync(x => x.Id == elem.CreatorId);
            
            ViewData["userExecutes"] = userExecutes;
            ViewData["user"] = user;
            ViewData["Title"] = elem.Title;
            ViewData["emailUserExecutes"] = userExecutes.Email;

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
            Thread.Sleep(10);
            var userId = await _context.User.FirstAsync(x => x.Email == note.CreatorId);
            var newNote = new Note()
            {
                CreatorId = userId.Id,
                IdUserExecutes = userId.Id,
                CardId = note.CardId,
                Card = note.Card,
                Title = note.Title,
                Description = note.Description,
                Text = note.Text,
                Comment = note.Comment,
                DateCreated = DateTime.UtcNow,
            };

            _context.Note.Add(newNote);
            await _context.SaveChangesAsync();

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
        public async Task<IActionResult> Edit(string id, [Bind("NoteId,CreatorId,CardId,Title,Description,Text,Comment,State,Priority")] Note note)
        {
            var updNote = await _context.Note
                .FirstOrDefaultAsync(x => x.NoteId == id);

            if (updNote == null)
                return NotFound();
            if (note.Title != null)
                updNote.Text = note.Text;
            if (note.Description != null)
                updNote.Description = note.Description;
            if (note.Comment != null)
                updNote.Comment = note.Comment;
            if (note.State != null)
                updNote.State = note.State;
            if (note.Priority != null)
                updNote.Priority = note.Priority;

            if(note.IdUserExecutes != null)
            {
                var elem = _context.User
                    .FirstOrDefault(x => x.Email == note.IdUserExecutes).Id;
                note.IdUserExecutes = elem;
            }

            updNote.DateUpdated = DateTime.UtcNow;

            _context.SaveChanges();

            return Redirect("Index/" + id);
        }

        public async Task<IActionResult> AddExecuted(string id, string personId)
        {

            var elem = await _context.Note
                .FirstAsync(x => x.NoteId == id);

            elem.IdUserExecutes = personId;
            _context.SaveChanges();

            return NotFound();
        }


        public async Task<IActionResult> UpdateCard(string id, string idNewCard)
        {
            var note = await _context.Note
                .FirstAsync(x => x.NoteId == id);
            var boardId = await _context.Card
                .FirstAsync(x => x.CardId == idNewCard);

            note.CardId = idNewCard;
          
            _context.SaveChanges();

            return Redirect("../../Board/Index/" + boardId.BoardId);
        }

        // GET: Note/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Note == null)
            {
                return NotFound();
            }

            var note = _context.Note
                .First(m => m.NoteId == id);

            var boardId = _context.Card
                .First(x => x.CardId == note.CardId)
                .BoardId;

            if (note == null)
            {
                return NotFound();
            }

            _context.Note.Remove(note);
            _context.SaveChanges();

            return Redirect("../../Board/Index/" + boardId);
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
