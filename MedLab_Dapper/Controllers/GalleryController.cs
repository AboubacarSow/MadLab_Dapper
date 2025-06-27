using MedLab_Dapper.Dtos.GalleryDtos;
using MedLab_Dapper.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MedLab_Dapper.Controllers;
[Route("Admin/[controller]/{action=Index}/{id?}")]
public class GalleryController : Controller
{
    private readonly IRepositoryManager _manager;

    public GalleryController(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public async Task<IActionResult> Index()
    {
        var galleries = await _manager.Gallery.GetAllAsync();
        return View(galleries);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(GalleryDto gallery)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Invalid data provided.");
            return View(gallery);
        }
        await _manager.Gallery.CreateAsync(gallery);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        var gallery = await _manager.Gallery.GetByIdAsync(id);
        return View(gallery);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(GalleryDto gallery)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Invalid data provided.");
            return View(gallery);
        }
        await _manager.Gallery.UpdateAsync(gallery);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _manager.Gallery.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}



