using MedLab_Dapper.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedLab_Dapper.ViewComponents;

public class StatisticViewComponent :ViewComponent
{
    private readonly IRepositoryManager _manager;
    public StatisticViewComponent(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        ViewBag.Doctors= (await _manager.Doctor.GetAllAsync()).Count();
        ViewBag.Departments=(await _manager.Department.GetAllDepartmentAsync()).Count();
        ViewBag.Avis=(await _manager.Testimonial.GetAllAsync()).Count();
        ViewBag.Messages=(await _manager.Message.GetAllAsync()).Count();

        return View();
    }
}

