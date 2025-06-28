using MedLab_Dapper.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedLab_Dapper.ViewComponents;

public class FrequentlyQuestionViewComponent : ViewComponent
{
    private readonly IRepositoryManager _manager;
    public FrequentlyQuestionViewComponent(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var questions = await _manager.FrequentlyQuestion.GetAllAsync();
        return View(questions);
    }
}
