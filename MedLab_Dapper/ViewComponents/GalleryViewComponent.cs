using MedLab_Dapper.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MedLab_Dapper.ViewComponents;

public class GalleryViewComponent: ViewComponent
{
    private readonly IRepositoryManager repositoryManager;
    public GalleryViewComponent(IRepositoryManager repositoryManager)
    {
        this.repositoryManager = repositoryManager;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var galleries=await repositoryManager.Gallery.GetAllAsync();    
        return View(galleries); 
    }
}
