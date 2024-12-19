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
        return View(sessions); 
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(Session session)
    {
        if (ModelState.IsValid)
        {
            await _sessionService.AddAsync(session);
            return RedirectToAction("Index");
        }
        return View(session);
    }

    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var session = await _sessionService.GetByIdAsync(id);
        if (session == null)
        {
            return NotFound();
        }
        return View(session);
    }

    [HttpPost("edit/{id}")]
    public async Task<IActionResult> Edit(Session session)
    {
        if (ModelState.IsValid)
        {
            await _sessionService.EditAsync(session);
            return RedirectToAction("Index");
        }
        return View(session);
    }

    [HttpPost("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _sessionService.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}

