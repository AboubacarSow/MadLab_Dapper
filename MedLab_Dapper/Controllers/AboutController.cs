using MedLab_Dapper.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MedLab_Dapper.Controllers;


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
    public ActionResult Create(IFormCollection collection)
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

    // GET: AboutController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: AboutController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
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

    // GET: AboutController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: AboutController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
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
}
