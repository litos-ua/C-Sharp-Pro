//using Microsoft.AspNetCore.Mvc;
//using WebApplicationNotes.Models;
//using WebApplicationNotes.Services;

//namespace WebApplicationNotes.Controllers
//{
//    //[ApiController]
//    //[Route("api/[controller]")]
//    public class NotesController : Controller
//    {
//        private readonly INoteService _noteService;

//        public NotesController(INoteService noteService)
//        {
//            _noteService = noteService;
//        }


//        [HttpGet]
//        public async Task<IActionResult> Index(CancellationToken cancellationToken)
//        {
//            var notes = await _noteService.GetAllNotesAsync(cancellationToken);
//            return View(notes); 
//        }

//        [HttpGet("{id:int}")]
//        public async Task<IActionResult> GetNoteById(int id, CancellationToken cancellationToken)
//        {
//            try
//            {
//                var note = await _noteService.GetNoteByIdAsync(id, cancellationToken);
//                return Ok(note);
//            }
//            catch (KeyNotFoundException ex)
//            {
//                return NotFound(new { message = ex.Message });
//            }
//        }

//        [HttpPost]
//        public async Task<IActionResult> AddNote([FromBody] Note note, CancellationToken cancellationToken)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            // Сохранение заметки
//            var createdNote = await _noteService.AddNoteAsync(note, cancellationToken);

//            // Возврат только необходимых данных
//            return CreatedAtAction(nameof(GetNoteById), new { id = createdNote.Id }, new
//            {
//                createdNote.Title,
//                createdNote.Content,
//                createdNote.Tags,
//                createdNote.ContactId,
//            });
//        }


//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateNote(int id, [FromBody] Note note, CancellationToken cancellationToken)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            if (id != note.Id)
//                return BadRequest(new { message = "ID mismatch." });

//            try
//            {
//                var updatedNote = await _noteService.UpdateNoteAsync(note, cancellationToken);
//                return Ok(updatedNote);
//            }
//            catch (KeyNotFoundException ex)
//            {
//                return NotFound(new { message = ex.Message });
//            }
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteNote(int id, CancellationToken cancellationToken)
//        {
//            var (success, message) = await _noteService.DeleteNoteAsync(id, cancellationToken);

//            if (!success)
//                return NotFound(new { message });

//            return NoContent();
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;
using WebApplicationNotes.Models;
using WebApplicationNotes.Services;

namespace WebApplicationNotes.Controllers
{
    [Route("note")]
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        
        [HttpGet("index")]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var notes = await _noteService.GetAllNotesAsync(cancellationToken);
            return View(notes);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            try
            {
                var note = await _noteService.GetNoteByIdAsync(id, cancellationToken);
                return View(note); 
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }


        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }


        //[HttpPost("create")]
        //public async Task<IActionResult> Create(Note note, CancellationToken cancellationToken)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var createdNote = await _noteService.AddNoteAsync(note, cancellationToken);

        //    return CreatedAtAction(nameof(Details), new { id = createdNote.Id }, createdNote);
        //}

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Note note, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Invalid data." });
            }

            try
            {
                var createdNote = await _noteService.AddNoteAsync(note, cancellationToken);
                return Json(new { success = true, message = "Note created successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        
        [HttpPost("edit/{id:int}")]
        public async Task<IActionResult> Edit(int id, [FromBody] Note note, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != note.Id)
                return BadRequest(new { message = "ID mismatch." });

            try
            {
                var updatedNote = await _noteService.UpdateNoteAsync(note, cancellationToken);
                return View(updatedNote);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var (success, message) = await _noteService.DeleteNoteAsync(id, cancellationToken);

            if (!success)
                return NotFound(new { message });

            return NoContent();
        }
        [HttpPost("test-template")]
        public IActionResult TestTemplate()
        {
            return View();
        }

    }

}

