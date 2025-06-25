using MedLab_Dapper.Dtos.DoctorDtos;
using MedLab_Dapper.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedLab_Dapper.Controllers
{
    public class DoctorController(IRepositoryManager _manager) : Controller
    {
        // GET: DoctorController
        public async Task<ActionResult> Index()
        {
            var doctors = await _manager.Doctor.GetAllWithDepartmentAsync();
            return View(doctors);
        }

        // GET: DoctorController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Departments = await  GetDepartmentsIds();
            return View();
        }

        private async Task<List<SelectListItem>>  GetDepartmentsIds()
        {
           var departments=(from dep in await _manager.Department.GetAllDepartmentAsync()
                               select new SelectListItem()
                               {
                                   Text = dep.DepartmentName,
                                   Value = dep.DepartmentId.ToString()
                               }).ToList();
            return departments;
        }

        // POST: DoctorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateDoctorDto model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = await GetDepartmentsIds();
                return View(model);

            }
            await _manager.Doctor.CreateOneDoctorAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: DoctorController/Edit/5
        public async Task<ActionResult> Update(int id)
        {
            var model = await _manager.Doctor.GetByIdAsync(id);
            ViewBag.Departments = await GetDepartmentsIds();
            return View(model);
        }

        // POST: DoctorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(UpdateDoctorDto model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = await GetDepartmentsIds();
                return View(model);
            }
            await _manager.Doctor.UpdateOneDoctorAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: DoctorController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            await _manager.Doctor.DeleteOneDoctorAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: DoctorController/Delete/5
        
    }
}
