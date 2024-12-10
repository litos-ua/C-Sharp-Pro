using WebApplicationNotes.Models;

namespace WebApplicationNotes.Services
{
    public interface INoteService
    {
        Task<IEnumerable<Note>> GetAllNotesAsync(CancellationToken cancellationToken);
        Task<Note> GetNoteByIdAsync(int id, CancellationToken cancellationToken);
        Task<Note> AddNoteAsync(Note note, CancellationToken cancellationToken);
        Task<Note> UpdateNoteAsync(Note note, CancellationToken cancellationToken);
        Task<(bool, string)> DeleteNoteAsync(int id, CancellationToken cancellationToken);

        // Получить все заметки, связанные с конкретным контактом
        Task<IEnumerable<Note>> GetNotesByContactIdAsync(int contactId);
    }
}


