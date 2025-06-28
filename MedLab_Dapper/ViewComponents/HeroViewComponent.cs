using MedLab_Dapper.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MedLab_Dapper.ViewComponents;
public class HeroViewComponent : ViewComponent
{
    private readonly IRepositoryManager _manager;
    public HeroViewComponent(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var services =( await _manager.Service.GetAllAsync()).OrderByDescending(s=>s.Id).Take(3).ToList();
        return View(services);
    }
}
