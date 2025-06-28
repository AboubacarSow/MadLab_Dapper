using MedLab_Dapper.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MedLab_Dapper.ViewComponents;

public class DepartmentViewComponent:ViewComponent
{
    private readonly IRepositoryManager _manager;
    public DepartmentViewComponent(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var dep=await _manager.Department.GetAllDepartmentAsync();
        return View(dep);
    }
}
