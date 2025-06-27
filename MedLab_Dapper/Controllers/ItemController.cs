using MedLab_Dapper.Dtos.ItemDtos;
using MedLab_Dapper.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedLab_Dapper.Controllers;

[Route("Admin/[controller]/{action=Index}/{id?}")]
public class ItemController : Controller
{

    private readonly IRepositoryManager _repositoryManager;
    public ItemController(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    // GET: ItemController
    public async Task<ActionResult> Index()
    {
        var items = await _repositoryManager.Item.GetAllAsync();
        return View(items);
    }

    // GET: ItemController/Create
    public async Task<ActionResult> Create()
    {
        await GetAboutsAsync();
        return View();
    }

    private async Task GetAboutsAsync()
    {
        var abouts=await _repositoryManager.About.GetAllAsync();
        ViewBag.Abouts = (from about in abouts
                          select new SelectListItem
                          {
                              Text=about.AboutId.ToString(),
                              Value=about.AboutId.ToString()
                          }).ToList();

    }

    // POST: ItemController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(CreateItemDto item)
    {
        try
        {
            await _repositoryManager.Item.CreateAsync(item);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            await GetAboutsAsync();
            return View();
        }
    }

    // GET: ItemController/Edit/5
    public async Task<ActionResult> Update(int id)
    {
        var item = await _repositoryManager.Item.GetByIdAsync(id);
        await GetAboutsAsync();
        return View(item);
    }

    // POST: ItemController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Update(UpdateItemDto item)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
    public async Task<ActionResult> Delete(int id)
    {
       
            await _repositoryManager.Item.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
     
    }
}
