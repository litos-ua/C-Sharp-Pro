using Microsoft.EntityFrameworkCore;
using WebApplicationNotes.Data;
using WebApplicationNotes.Models;

namespace WebApplicationNotes.Services
{
    public class NoteService : INoteService
    {
        private readonly AppDbContext _db;

        public NoteService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Note>> GetAllNotesAsync(CancellationToken cancellationToken)
        {
            return await _db.Notes.ToListAsync(cancellationToken);
        }

        public async Task<Note> GetNoteByIdAsync(int id, CancellationToken cancellationToken)
        {
            var note = await _db.Notes.FindAsync(new object[] { id }, cancellationToken);

            if (note == null)
                throw new KeyNotFoundException($"Note with Id {id} not found.");

            return note;
        }

        public async Task<Note> AddNoteAsync(Note note, CancellationToken cancellationToken)
        {
            await _db.Notes.AddAsync(note, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
            return note;
        }

        public async Task<Note> UpdateNoteAsync(Note note, CancellationToken cancellationToken)
        {
            _db.Entry(note).State = EntityState.Modified;
            await _db.SaveChangesAsync(cancellationToken);

            return note;
        }

        public async Task<(bool, string)> DeleteNoteAsync(int id, CancellationToken cancellationToken)
        {
            var note = await _db.Notes.FindAsync(new object[] { id }, cancellationToken);
            if (note == null)
            {
                return (false, "Note not found.");
            }

            try
            {
                _db.Notes.Remove(note);
                await _db.SaveChangesAsync(cancellationToken);
                return (true, "Note deleted successfully.");
            }
            catch (Exception ex)
            {
                return (false, $"Error while deleting note: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Note>> GetNotesByContactIdAsync(int contactId)
        {
            return await _db.Notes
                .Where(n => n.ContactId == contactId)
                .ToListAsync();
        }
    }
}

