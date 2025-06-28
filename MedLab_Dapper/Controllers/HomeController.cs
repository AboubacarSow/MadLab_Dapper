using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MedLab_Dapper.Models;
using MedLab_Dapper.Dtos.MessageDtos;
using MedLab_Dapper.Repositories.Contracts;
using System.Threading.Tasks;
using MedLab_Dapper.Dtos.AppointmentDtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedLab_Dapper.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IRepositoryManager _manager;

    public HomeController(ILogger<HomeController> logger, IRepositoryManager manager)
    {
        _logger = logger;
        _manager = manager;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> SendMessage([FromBody] CreateMessageDto message)
    {
        try
        {
            await _manager.Message.CreateAsync(message);
            return Json(new {success= true});   
        }
        catch (Exception ex)
        {
            return Json( new {success=false, message = ex.Message});
        }
    }

    [HttpPost]
    public async Task<IActionResult> MakeAppointment([FromBody]CreateAppointmentDto appointment)
    {
        try
        {
            await _manager.Appointment.CreateAsync(appointment);
            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = ex.Message });
        }
          
    }
    public async Task<IActionResult> GetDoctorsByDepartmentAsync(int departmentId)
    {
        var doctors = await _manager.Doctor.GetDoctorsByDepartmentAsync(departmentId);

        var doctorList = (from d in doctors
                          select new SelectListItem
                          {
                              Text=d.FullName,
                              Value=d.DoctorId.ToString()
                          }).ToList();

        return Json(doctorList);
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
