using MedLab_Dapper.Dtos.FrequentlyQuestionDtos;
using MedLab_Dapper.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MedLab_Dapper.Controllers;

[Route("Admin/[controller]/{action=Index}/{id?}")]
public class FrequentlyQuestionController : Controller
{
    private readonly IRepositoryManager _repositoryManager;

    public FrequentlyQuestionController(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<IActionResult> Index()
    {
        var questions = await _repositoryManager.FrequentlyQuestion.GetAllAsync();
        return View(questions);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateFrequentlyQuestionDto questionDto)
    {
        if (!ModelState.IsValid)
            return View(questionDto);
        await _repositoryManager.FrequentlyQuestion.CreateAsync(questionDto);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        var question = await _repositoryManager.FrequentlyQuestion.GetByIdAsync(id);
        return View(question);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(UpdateFrequentlyQuestionDto questionDto)
    {
        if (!ModelState.IsValid)
            return View(questionDto);
        await _repositoryManager.FrequentlyQuestion.UpdateAsync(questionDto);
        return RedirectToAction(nameof(Index));
    }   
    public async Task<IActionResult> Delete(int id)
    {
        await _repositoryManager.FrequentlyQuestion.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}

