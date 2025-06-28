using MedLab_Dapper.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MedLab_Dapper.ViewComponents;

public class AboutViewComponent :ViewComponent
{
    private readonly IRepositoryManager _manager;
    public AboutViewComponent(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
       var about=(await _manager.About.GetAllAsync()).OrderByDescending(b=>b.AboutId).Take(1).FirstOrDefault();
        return View(about);
    }
}
