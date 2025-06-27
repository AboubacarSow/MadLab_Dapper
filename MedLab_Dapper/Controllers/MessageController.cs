using MedLab_Dapper.Dtos.MessageDtos;
using MedLab_Dapper.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MedLab_Dapper.Controllers;

[Route("Admin/[controller]/{action=Index}/{id?}")]
public class MessageController : Controller
{
    private readonly IRepositoryManager _repositoryManager;

    public MessageController(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    // GET: MessageController
    public async Task<ActionResult> Index()
    {
        var messages = await _repositoryManager.Message.GetAllAsync();
        return View(messages);
    }

    // GET: MessageController/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: MessageController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(CreateMessageDto messageDto)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Invalid data provided.");
            return View(messageDto);
        }

        await _repositoryManager.Message.CreateAsync(messageDto);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id)
    {
        await _repositoryManager.Message.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }   
}