using CinemaPoster.Domain.Models;
using CinemaPoster.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("sessions")]
public class SessionsController : Controller
{
    private readonly ISessionService _sessionService;

    public SessionsController(ISessionService sessionService)
    {
        _sessionService = sessionService ?? throw new ArgumentNullException(nameof(sessionService));
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var sessions = await _sessionService.GetAllAsync();
        return View("~/Views/Admin/Sessions.cshtml", sessions); 
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View("~/Views/Admin/Sessions/Create.cshtml");
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(Session session)
    {
        if (ModelState.IsValid)
        {
            await _sessionService.AddAsync(session);
            return RedirectToAction("Index");
        }
        return View("~/Views/Admin/Sessions.cshtml", session);
    }

    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var session = await _sessionService.GetByIdAsync(id);
        if (session == null)
        {
            return NotFound();
        }
        return View("~/Views/Admin/Sessions/Edit.cshtml", session);
    }

    [HttpPost("edit/{id}")]
    public async Task<IActionResult> Edit(Session session)
    {
        if (ModelState.IsValid)
        {
            await _sessionService.EditAsync(session);
            return RedirectToAction("Index");
        }
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            foreach (var error in errors)
            {
                Console.WriteLine(error); 
            }
            return View("~/Views/Admin/Sessions/Edit.cshtml", session);
        }
        return View("~/Views/Admin/Sessions/Edit.cshtml", session);
    }

    [HttpPost("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _sessionService.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}

