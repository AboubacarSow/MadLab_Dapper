using MedLab_Dapper.Dtos.DepartmentDtos;
using MedLab_Dapper.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MedLab_Dapper.Controllers;

[Route("Admin/[controller]/{action=Index}/{id?}")]
public class DepartmentController(IRepositoryManager manager) : Controller
{
    private readonly IRepositoryManager _manager = manager;
    // GET: DepartmentController
    public async Task<ActionResult> Index()
    {
        var model = await _manager.Department.GetAllDepartmentAsync();
        return View(model);
    }


    // GET: DepartmentController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: DepartmentController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(CreateDepartmentDto department)
    {
        if (!ModelState.IsValid)
            return View(department);
        await _manager.Department.CreateOneDepartment(department);
        return RedirectToAction(nameof(Index));       
    }

    // GET: DepartmentController/Edit/5
    public async Task<ActionResult> Update(int id)
    {
        var model = await _manager.Department.GetDepartmentByIdAsync(id);
        return View(model);
    }

    // POST: DepartmentController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Update(UpdateDepartmentDto model)
    {
        if (!ModelState.IsValid)
            return View(model);
        await _manager.Department.UpdateOneDepartmentAsync(model);
        return RedirectToAction(nameof(Index));
    }

    // Post: DepartmentController/Delete/5
    public async Task<ActionResult> Delete(int id)
    {
        await _manager.Department.DeleteOneDepartmentAsync(id);
        return RedirectToAction(nameof(Index));
    }

    
    
}
