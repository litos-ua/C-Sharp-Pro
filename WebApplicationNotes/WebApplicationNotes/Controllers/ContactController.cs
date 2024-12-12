using Microsoft.AspNetCore.Mvc;
using WebApplicationNotes.Models;
using WebApplicationNotes.Services;

namespace WebApplicationNotes.Controllers
{
    [Route("contact")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("index")]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var contacts = await _contactService.GetAllContactsAsync(cancellationToken);
            return View(contacts);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            try
            {
                var contact = await _contactService.GetContactByIdAsync(id, cancellationToken);
                return View(contact);
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

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Contact contact, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Invalid data." });
            }

            try
            {
                var createdContact = await _contactService.AddContactAsync(contact, cancellationToken);
                return Json(new { success = true, message = "Contact created successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet("edit/{id:int}")]
        public async Task<IActionResult> Edit(int? id, CancellationToken cancellationToken)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var contact = await _contactService.GetContactByIdAsync(id.Value, cancellationToken);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit([FromBody] Contact contact, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Invalid data.",
                    errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }

            try
            {
                var updatedContact = await _contactService.UpdateContactAsync(contact, cancellationToken);
                return Ok(new
                {
                    success = true,
                    message = "Contact updated successfully.",
                    data = updatedContact
                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An internal server error.", error = ex.Message });
            }
        }

        [HttpGet("delete/{id:int}")]
        public async Task<IActionResult> Delete(int? id, CancellationToken cancellationToken)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var contact = await _contactService.GetContactByIdAsync(id.Value, cancellationToken);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpPost("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var (success, message) = await _contactService.DeleteContactAsync(id, cancellationToken);

            if (!success)
            {
                return Json(new { success = false, message });
            }

            return Json(new { success = true, message = "Contact deleted successfully." });
        }
    }
}

