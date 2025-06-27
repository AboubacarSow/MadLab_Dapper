using MedLab_Dapper.Dtos.ServiceDtos;
using MedLab_Dapper.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MedLab_Dapper.Controllers;
[Route("Admin/[controller]/{action=Index}/{id?}")]
public class ServiceController : Controller
{
    private readonly IRepositoryManager _repositoryManager;
    public ServiceController(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<IActionResult> Index()
    {
        var services = await _repositoryManager.Service.GetAllAsync();
        return View(services);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateServiceDto serviceDto)
    {
        if (!ModelState.IsValid)
            return View(serviceDto);
        
        await _repositoryManager.Service.CreateAsync(serviceDto);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        var service = await _repositoryManager.Service.GetByIdAsync(id);
        return View(service);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(UpdateServiceDto serviceDto)
    {
        if (!ModelState.IsValid)
            return View(serviceDto);
        
        await _repositoryManager.Service.UpdateAsync(serviceDto);
        return RedirectToAction(nameof(Index));
    }   

    public async Task<IActionResult> Delete(int id)
    {
        await _repositoryManager.Service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}