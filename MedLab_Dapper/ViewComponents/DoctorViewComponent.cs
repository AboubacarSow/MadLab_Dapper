using MedLab_Dapper.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MedLab_Dapper.ViewComponents;

public class DoctorViewComponent : ViewComponent
{
    private readonly IRepositoryManager _manager;
    public DoctorViewComponent(IRepositoryManager manager)
    {
        _manager = manager;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var doctors = await _manager.Doctor.GetAllWithDepartmentAsync();
        return View(doctors);  
    }
}
