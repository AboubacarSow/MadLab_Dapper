using MedLab_Dapper.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MedLab_Dapper.ViewComponents;

public class ContactViewComponent : ViewComponent
{
    private readonly IRepositoryManager _manager;
    public ContactViewComponent(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var contact=(await _manager.Contact.GetAllAsync()).OrderByDescending(c=>c.ContactId).Take(1).First();
        return View(contact);
    }
}
