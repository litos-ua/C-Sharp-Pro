using Microsoft.EntityFrameworkCore;
using WebApplicationNotes.Data;
using WebApplicationNotes.Models;

namespace WebApplicationNotes.Services
{
    public class ContactService : IContactService
    {
        private readonly AppDbContext _db;

        public ContactService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync(CancellationToken cancellationToken)
        {
            return await _db.Contacts.ToListAsync(cancellationToken);
        }

        public async Task<Contact> GetContactByIdAsync(int id, CancellationToken cancellationToken = default, bool includeNotes = false)
        {
            var contact = includeNotes
        ? await _db.Contacts.Include(n => n.Notes).FirstOrDefaultAsync(i => i.Id == id, cancellationToken)
        : await _db.Contacts.FindAsync(new object[] { id }, cancellationToken);

            if (contact == null)
                throw new KeyNotFoundException($"Contact with Id {id} not found.");

            return contact;
            //return includeNotes ? 
            //    await _db.Contacts.Include(n => n.Notes).FirstOrDefaultAsync(i => i.Id == id) :
            //    await _db.Contacts.FindAsync(id);
        }

        public async Task<Contact> AddContactAsync(Contact contact, CancellationToken cancellationToken)
        {
            await _db.Contacts.AddAsync(contact, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
            return contact;
        }

        public async Task<Contact> UpdateContactAsync(Contact contact, CancellationToken cancellationToken = default)
        {
            _db.Entry(contact).State = EntityState.Modified;
            await _db.SaveChangesAsync(cancellationToken);

            return contact;
        }


        public async Task<(bool, string)> DeleteContactAsync(int id, CancellationToken cancellationToken)
        {
            var contact = await _db.Contacts.FindAsync(new object[] { id }, cancellationToken);
            if (contact == null)
            {
                return (false, "Contact not found.");
            }

            try
            {
                _db.Contacts.Remove(contact);
                await _db.SaveChangesAsync(cancellationToken);
                return (true, "Contact deleted successfully.");
            }
            catch (Exception ex)
            {
                return (false, $"Error while deleting contact: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Note>> GetNotesByContactIdAsync(int contactId)
        {
            return await _db.Notes
                .Where(n => n.ContactId == contactId)
                .ToListAsync();
        }

        public async Task<Contact> AddNoteToContactAsync(int contactId, Note note)
        {
            var contact = await _db.Contacts.FindAsync(contactId);
            if (contact == null)
            {
                return null; // Контакт не найден
            }

            note.ContactId = contactId;
            await _db.Notes.AddAsync(note);
            await _db.SaveChangesAsync();
            return contact;
        }
    }
}

