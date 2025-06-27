using MedLab_Dapper.Dtos.SocialMediaDtos;
using MedLab_Dapper.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MedLab_Dapper.Controllers;
[Route("Admin/[controller]/{action=Index}/{id?}")]
public class SocialMediaController : Controller
{
    private readonly IRepositoryManager _manager;
    public SocialMediaController(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public async Task<IActionResult> Index()
    {
        var socialMedias = await _manager.SocialMedia.GetAllAsync();
        return View(socialMedias);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateSocialMediaDto socialMedia)
    {
        if (!ModelState.IsValid)
            return View(socialMedia);
        
        await _manager.SocialMedia.CreateAsync(socialMedia);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        var socialMedia = await _manager.SocialMedia.GetByIdAsync(id);
        return View(socialMedia);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(UpdateSocialMediaDto socialMedia)
    {
        if (!ModelState.IsValid) 
            return View(socialMedia);
        
        await _manager.SocialMedia.UpdateAsync(socialMedia);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id)
    {
        await _manager.SocialMedia.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}