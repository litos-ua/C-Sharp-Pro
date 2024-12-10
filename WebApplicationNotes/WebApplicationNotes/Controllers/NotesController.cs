using Microsoft.AspNetCore.Mvc;
using WebApplicationNotes.Models;
using WebApplicationNotes.Services;

namespace WebApplicationNotes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotes(CancellationToken cancellationToken)
        {
            var notes = await _noteService.GetAllNotesAsync(cancellationToken);
            return Ok(notes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoteById(int id, CancellationToken cancellationToken)
        {
            try
            {
                var note = await _noteService.GetNoteByIdAsync(id, cancellationToken);
                return Ok(note);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> AddNote([FromBody] Note note, CancellationToken cancellationToken)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var createdNote = await _noteService.AddNoteAsync(note, cancellationToken);
        //    return CreatedAtAction(nameof(GetNoteById), new { id = createdNote.Id }, createdNote);
        //}

        [HttpPost]
        public async Task<IActionResult> AddNote([FromBody] Note note, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Сохранение заметки
            var createdNote = await _noteService.AddNoteAsync(note, cancellationToken);

            // Возврат только необходимых данных
            return CreatedAtAction(nameof(GetNoteById), new { id = createdNote.Id }, new
            {
                createdNote.Title,
                createdNote.Content,
                createdNote.Tags,
                createdNote.ContactId,
            });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(int id, [FromBody] Note note, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != note.Id)
                return BadRequest(new { message = "ID mismatch." });

            try
            {
                var updatedNote = await _noteService.UpdateNoteAsync(note, cancellationToken);
                return Ok(updatedNote);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id, CancellationToken cancellationToken)
        {
            var (success, message) = await _noteService.DeleteNoteAsync(id, cancellationToken);

            if (!success)
                return NotFound(new { message });

            return NoContent();
        }
    }
}

