using System.Threading.Tasks;
using MedLab_Dapper.Dtos.ContactDtos;
using MedLab_Dapper.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MedLab_Dapper.Controllers;

[Route("Admin/[controller]/{action=Index}/{id?}")]
public class ContactController : Controller
{
    private readonly IRepositoryManager _manager;
    public ContactController(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public async Task<IActionResult> IndexAsync()
    {
        var contacts = await _manager.Contact.GetAllAsync();
        return View(contacts);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateContactDto contact)
    {
        if (!ModelState.IsValid)
            return View(contact);
        await _manager.Contact.CreateAsync(contact);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        var contact = await _manager.Contact.GetByIdAsync(id);
        return View(contact);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateAsync(UpdateContactDto contact)
    {
        if (!ModelState.IsValid) return View(contact);
        await _manager.Contact.UpdateAsync(contact);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _manager.Contact.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}