using MedLab_Dapper.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MedLab_Dapper.ViewComponents;

public class ServiceViewComponent : ViewComponent
{
    private readonly IRepositoryManager _manager;
    public ServiceViewComponent(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var services = (await _manager.Service.GetAllAsync()).OrderByDescending(s => s.Id).ToList();
        return View(services);
    }
}
