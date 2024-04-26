using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Page_BLL.Interfaces;
using Page_BLL.Repositories;
using Page_DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Page_Pl.Controllers
{
	[Authorize]

	public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(string Search )
        {
            //Get all
            IEnumerable<Department> dep;
            if (string.IsNullOrEmpty(Search))
                dep = await _unitOfWork.DepartmentRepository.GetAllByAsync();
            else
                dep= _unitOfWork.DepartmentRepository.GetDepartmentsByName(Search);
            return View(dep);
           
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
           if(ModelState.IsValid)
           {
                await _unitOfWork.DepartmentRepository.AddByAsync(department);
                int res = await _unitOfWork.CompeleteByAsync();
                if (res > 0) TempData["Message"] = "Department Is Created";
                return RedirectToAction("Index");
           }
           return View(department);
        } 

        public async Task<IActionResult>Details(int? id,string Viewname="Details")
        {
            if (id == null) return BadRequest();
            var dep =await _unitOfWork.DepartmentRepository.GetByIdByAsync(id.Value);
            if(dep == null) return NotFound();
            return View(Viewname,dep);
        }

        [HttpGet] // Browser
        public async Task<IActionResult>Edit(int?id)
        {
            /*if (id is null) return BadRequest();
            var dep = _departmentRepository.GetById(id.Value);
            if (dep == null) return NotFound();
            return View(dep);*/
            return await Details(id, "Edit"); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Department department,[FromRoute] int id)
        {
            if(id !=department.Id) return BadRequest();
            if (ModelState.IsValid) {
                try
                {
                     _unitOfWork.DepartmentRepository.Update(department);
                    await _unitOfWork.CompeleteByAsync();
                    return RedirectToAction("Index");
                }
                catch(System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(department);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return await Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Department department, [FromRoute] int id)
        {
            if (id != department.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.DepartmentRepository.Delete(department);
                    await _unitOfWork.CompeleteByAsync();
                    return RedirectToAction("Index");
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(department);
        }
    }
}
