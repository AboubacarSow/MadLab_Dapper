using MedLab_Dapper.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MedLab_Dapper.ViewComponents;

public class TestimonialViewComponent : ViewComponent
{
    private readonly IRepositoryManager _manager;

    public TestimonialViewComponent(IRepositoryManager manager)
    {
        _manager = manager;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var testimonial=await _manager.Testimonial.GetAllAsync();
        return View(testimonial);
    }
}
