using Microsoft.AspNetCore.Mvc;

namespace MedLab_Dapper.ViewComponents;

public class AppointmentViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();  
    }
}
