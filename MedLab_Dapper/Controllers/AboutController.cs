using MedLab_Dapper.Dtos.AboutDtos;
using MedLab_Dapper.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MedLab_Dapper.Controllers;

[Route("Admin/[controller]/{action=Index}/{id?}")]
public class AboutController : Controller
{
    private readonly IRepositoryManager _repositoryManager;
    public AboutController(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    // GET: AboutController
    public async Task<ActionResult> Index()
    {
        var abouts= await _repositoryManager.About.GetAllAsync();
        return View(abouts);
    }

    // GET: AboutController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: AboutController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(CreateAboutDto about)
    {
        try
        {
            await _repositoryManager.About.CreateAsync(about);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View(about);
        }
    }

    // GET: AboutController/Edit/5
    public async Task<ActionResult> Update(int id)
    {
        var about = await _repositoryManager.About.GetByIdAsync(id);
        return View(about);
    }

    // POST: AboutController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Update(UpdateAboutDto update)
    {
        try
        {
            await _repositoryManager.About.UpdateAsync(update);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View(update);
        }
    }

    // GET: AboutController/Delete/5
    public async Task<ActionResult> Delete(int id)
    {
        await _repositoryManager.About.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }

    // POST: AboutController/Delete/5
  
}
