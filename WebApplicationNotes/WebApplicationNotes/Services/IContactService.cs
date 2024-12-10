using System.Threading.Tasks;
using WebApplicationNotes.Models;

namespace WebApplicationNotes.Services
{
    public interface IContactService
    {
        // Методы для работы с контактами
        Task<IEnumerable<Contact>> GetAllContactsAsync(CancellationToken cancellationToken);
        Task<Contact> GetContactByIdAsync(int id, CancellationToken cancellationToken, bool includeNotes = false);
        Task<Contact> AddContactAsync(Contact contact, CancellationToken cancellationToken);
        Task<Contact> UpdateContactAsync(Contact contact, CancellationToken cancellationToken = default);
        Task<(bool, string)> DeleteContactAsync(int id, CancellationToken cancellationToken);

        // Методы для работы с заметками конкретного контакта
        Task<IEnumerable<Note>> GetNotesByContactIdAsync(int contactId);
        Task<Contact> AddNoteToContactAsync(int contactId, Note note);
    }
}

