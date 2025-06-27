using MedLab_Dapper.Dtos.SocialMediaDtos;
using MedLab_Dapper.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using System.Threading.Tasks;

namespace MedLab_Dapper.Controllers;
[Route("Admin/[controller]/{action=Index}/{id?}")]
public class SocialMediaController : Controller
{
    private readonly IRepositoryManager _manager;
    public SocialMediaController(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public async Task<IActionResult> Index()
    {
        var socialMedias = await _manager.SocialMedia.GetAllAsync();
        return View(socialMedias);
    }

    private async Task GetDoctors()
    {
        var doctors= await _manager.Doctor.GetAllAsync();
        ViewBag.Doctors = (from d in doctors
                           select new SelectListItem
                           {
                               Text=d.FullName,
                               Value=d.DoctorId.ToString()  
                           }).ToList();
    }
    public async Task<IActionResult> Create()
    {
        await GetDoctors();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateSocialMediaDto socialMedia)
    {
        if (!ModelState.IsValid)
        {
            await GetDoctors();
            return View(socialMedia);
        }
        
        await _manager.SocialMedia.CreateAsync(socialMedia);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        await GetDoctors();
        var socialMedia = await _manager.SocialMedia.GetByIdAsync(id);
        return View(socialMedia);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(UpdateSocialMediaDto socialMedia)
    {
        if (!ModelState.IsValid)
        {
            await GetDoctors();
            return View(socialMedia);
        }        
        await _manager.SocialMedia.UpdateAsync(socialMedia);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id)
    {
        await _manager.SocialMedia.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}