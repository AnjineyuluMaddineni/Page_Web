using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Page_BLL.Interfaces;
using Page_DAL.Models;
using Page_Pl.Helper;
using Page_Pl.ModelsView;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Page_Pl.Controllers
{
	[Authorize]

	public class EmployeeController : Controller
    {
  
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _UnitOfWork;
        public EmployeeController(IUnitOfWork unitOfWork,IMapper mapper) { 
          
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(string Search)
        {
            //Get all
            IEnumerable<Employee> emp;
            if (string.IsNullOrEmpty(Search)) 
                 emp=await _UnitOfWork.EmployeeRepository.GetAllByAsync();
            else
                 emp =_UnitOfWork.EmployeeRepository.GetEmployeesByName(Search);
               
		
           var empView = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeModelView>>(emp);
                return View(empView);
        }

        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeModelView employee)
        {
            if(ModelState.IsValid)
            {
             
                    employee.ImageName=DocSettgings.UploadFile(employee.Image, "Images");
                var emp=_mapper.Map<EmployeeModelView,Employee>(employee);
                 await _UnitOfWork.EmployeeRepository.AddByAsync(emp);
                int res = await _UnitOfWork.CompeleteByAsync();

                 if(res>0)
                 TempData["Message"] = "Employee Is Created";
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public async Task<IActionResult> Details(int?id,string ViewName="Details")
        {
            if (id == null) return BadRequest();
            var emp = await _UnitOfWork.EmployeeRepository.GetByIdByAsync(id.Value);
             if(emp == null) return NotFound(); 
            var empView = _mapper.Map<Employee, EmployeeModelView>(emp);
            return View(ViewName,empView);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int ?id)
        {
            return await Details(id,"Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeModelView employeeView,[FromRoute]int id)
        {
            if(id!=employeeView.Id)return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    employeeView.ImageName = DocSettgings.UploadFile(employeeView.Image, "Images");
                    var emp = _mapper.Map<EmployeeModelView,Employee>(employeeView);
                    _UnitOfWork.EmployeeRepository.Update(emp);
                   await _UnitOfWork.CompeleteByAsync();
                    return RedirectToAction("Index");
                }
                catch(System.Exception ex) {
                  ModelState.AddModelError(string.Empty,ex.Message);
                }
            }

            return View(employeeView);
        }

		[HttpGet]
		public async Task<IActionResult> Delete(int? id)
		{
			return await Details(id, "Delete");
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(EmployeeModelView employeeView, int id)
		{
			if (id != employeeView.Id) return BadRequest();
			if (ModelState.IsValid)
			{
				try
				{
                    var emp = _mapper.Map<EmployeeModelView, Employee>(employeeView);
                    _UnitOfWork.EmployeeRepository.Delete(emp);
                   int res= await _UnitOfWork.CompeleteByAsync();
                    if (res > 0&&emp.ImageName is not null)
                    {
                        DocSettgings.DeleteFile(emp.ImageName, "Images");
                    }
                    return RedirectToAction("Index");
				}
				catch (System.Exception ex)
				{
					ModelState.AddModelError(string.Empty, ex.Message);
				}
			}
			return View(employeeView);
		}
	}
}
