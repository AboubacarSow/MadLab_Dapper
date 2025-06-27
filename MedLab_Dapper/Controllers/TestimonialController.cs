using MedLab_Dapper.Dtos.TestimonialDtos;
using MedLab_Dapper.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MedLab_Dapper.Controllers;

[Route("Admin/[controller]/{action=Index}/{id?}")]
public class TestimonialController : Controller
{
    private readonly IRepositoryManager _manager;
    public TestimonialController(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public async Task<IActionResult> Index()
    {
        var testimonials = await _manager.Testimonial.GetAllAsync();
        return View(testimonials);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateTestimonialDto testimonial)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Invalid data provided.");
            return View(testimonial);
        }
        await _manager.Testimonial.CreateAsync(testimonial);
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var testimonial = await _manager.Testimonial.GetByIdAsync(id);
        return View(testimonial);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(UpdateTestimonialDto testimonial)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Invalid data provided.");
            return View(testimonial);
        }
        await _manager.Testimonial.UpdateAsync(testimonial);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id)
    {
        await _manager.Testimonial.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }

}