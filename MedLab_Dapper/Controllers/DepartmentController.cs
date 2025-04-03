using MedLab_Dapper.Dtos.DepartmentDtos;
using MedLab_Dapper.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedLab_Dapper.Controllers
{
    public class DepartmentController(IDepartmentRepository department) : Controller
    {
        private readonly IDepartmentRepository _department = department;
        // GET: DepartmentController
        public async Task<ActionResult> Index()
        {
            var model = await _department.GetAllDepartmentAsync();
            return View(model);
        }


        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateDepartmentDto department)
        {
            if (!ModelState.IsValid)
                return View(department);
            await _department.CreateOneDepartment(department);
            return RedirectToAction(nameof(Index));       
        }

        // GET: DepartmentController/Edit/5
        public async Task<ActionResult> Update(int id)
        {
            var model = await _department.GetDepartmentByIdAsync(id);
            return View(model);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(UpdateDepartmentDto model)
        {
            if (!ModelState.IsValid)
                return View(model);
            await _department.UpdateOneDepartmentAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // Post: DepartmentController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            await _department.DeleteOneDepartmentAsync(id);
            return RedirectToAction(nameof(Index));
        }

        
        
    }
}
