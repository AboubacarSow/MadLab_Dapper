using MedLab_Dapper.Dtos.AppointmentDtos;
using MedLab_Dapper.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MedLab_Dapper.Controllers;

[Route("Admin/[controller]/{action=Index}/{id?}")]
public class AppointmentController : Controller
{
    private readonly IRepositoryManager _repositoryManager;

    public AppointmentController(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    // GET: AppointmentController
    public async Task<ActionResult> Index()
    {
        var appointments = await _repositoryManager.Appointment.GetAllAsync();
        return View(appointments);
    }

    // GET: AppointmentController/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: AppointmentController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(CreateAppointmentDto appointmentDto)
    {
        try
        {
            await _repositoryManager.Appointment.CreateAsync(appointmentDto);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View(appointmentDto);
        }
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        await _repositoryManager.Appointment.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}