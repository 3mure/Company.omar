using Company.omar.DAL.Model;
using Company.omar.PL.Models;
using Company.omar.PLL.Interface;
using Company.omar.PLL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace Company.omar.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository repository) : base()
        {
            _departmentRepository = repository;
        }
        public IActionResult Index()
        {
            var departments = _departmentRepository.GetAllDepartments();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]

        public IActionResult Create(departmentdto model)
        {
            if (ModelState.IsValid)
            {
                var department = new Department()
                {
                    code = model.code,
                    Name = model.Name,
                    CreatedAt = model.CreatedAt
                };
                var count = _departmentRepository.AddDepartment(department);
                if (count > 0)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Details(int? Id, string viewName = "Details")
        {
            if (Id == null) { return NotFound(); }

            var department = _departmentRepository.GetDepartment(Id.Value);
            if (department==null) { return BadRequest(new { StatusCode = 404 ,Message=$"Department with id {Id} N" }); }

            return View(viewName,department);
        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            


            return Details(Id,"Edit");
        }
        [HttpPost]
        public IActionResult Edit([FromRoute] int Id,Department department)
        {
            if (Id != department.Id) { return NotFound(); }

            if (ModelState.IsValid)
            {
                var IsDepartmentUpdated = _departmentRepository.UpdateDepartment(department);
                if (IsDepartmentUpdated > 0) { return RedirectToAction(nameof(Index)); }
            }
            return View(department);
        }
        [HttpGet]
        public IActionResult Delete(int Id) 
        {
            
            return Details(Id,"Delete");
        
        }
        [HttpPost]
        public IActionResult Delete([FromRoute] int Id , Department department) 
        {
            if (Id == department.Id) 
            {
                if (department==null) { return BadRequest($"Department With Id Equal {Id} Not Found "); }
                if (department!=null) 
                {
                    var isDeleted = _departmentRepository.DeleteDepartment(department);
                   if (isDeleted > 0) 
                   {
                        return RedirectToAction(nameof(Index));
                   }

                } 
            }
         
         return View(department);
        
        }
       
       
            
    }
}
