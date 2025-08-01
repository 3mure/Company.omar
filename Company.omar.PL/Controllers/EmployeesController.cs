﻿using Company.omar.DAL.Model;
using Company.omar.PLL.Interface;
using Company.omar.PLL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Company.omar.PL.Controllers
{
    public class EmployeesController : Controller
    {
        //private readonly IEmployeeRepository _employeeRepository;
        //private readonly IDepartmentRepository _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesController(
            //IEmployeeRepository employeeRepository
            //, IDepartmentRepository departmentRepository
             IUnitOfWork unitOfWork
            )
        {
            _unitOfWork = unitOfWork;
            // _employeeRepository = employeeRepository;
            //_departmentRepository = departmentRepository;
        }
        public IActionResult Index(string? SearchInput)
        {
            IEnumerable<Employee> employees;
            if (!string.IsNullOrEmpty(SearchInput))
            {
                employees = _unitOfWork.employeeRepository.SearchByName(SearchInput);
                return View(employees);
            }
             employees = _unitOfWork. employeeRepository.GetAll();
            return View(employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var department = _unitOfWork. departmentRepository.GetAll();
            ViewData["department"] = department;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee model) 
        {
            var employee = new Employee() 
            {
             Id = model.Id,
             Name = model.Name,
             Address = model.Address,
             Age = model.Age,
             CreateAt = model.CreateAt,
             Email=model.Email,
             IsActive=model.IsActive,
             HiringDate=model.HiringDate,
             IsDeleted=model.IsDeleted,
             Phone=model.Phone,
             Salary=model.Salary,
             DepartmentId=model.DepartmentId,
             
            

            };
            if (ModelState.IsValid) 
            {
              _unitOfWork. employeeRepository.Add(model);

                var count = _unitOfWork.SaveChanges();
                if (count > 0) 
                {
                    TempData["Message"] = "Employee Is Created ... ... ";
                        
                    return RedirectToAction("Index");
                }
            }
            
             
            
         return View(model);
        }
        [HttpGet]
        public IActionResult Details(int Id,string ViewName="Details")
        {
            var employee = _unitOfWork. employeeRepository.Get(Id);
            if (employee == null) { return BadRequest(new { StatusCode = 404, Message = $"Employee with id {Id} Not fount" }); }
            return View(ViewName,employee);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var department = _unitOfWork. departmentRepository.GetAll();
            ViewData["department"] = department;

            return Details(Id,"Edit");
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            
            return Details(Id, "Delete");
        }
        [HttpPost]
        public IActionResult Edit( [FromRoute] int Id,Employee? employee) 
        {

            if (Id != employee.Id) 
            {
                return BadRequest(new { StatusCode = 400, Message = $"Employee with id {Id} Not fount" });
            }

            if (ModelState.IsValid) 
            {
              _unitOfWork. employeeRepository.Update(employee);
                var count = _unitOfWork.SaveChanges();
                if (count > 0) 
                {
                    return RedirectToAction("Index");
                }
            }
            return View(employee);
        }
        [HttpPost]
        public IActionResult Delete([FromRoute] int Id, Employee? employee)
        {
            if (Id != employee.Id)
            {
                return BadRequest(new { StatusCode = 400, Message = $"Employee with id {Id} Not fount" });
            }
            if (employee!=null)
            {
               
                _unitOfWork. employeeRepository.Delete(employee);
                var count = _unitOfWork.SaveChanges();
                if (count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(employee);
        }

    }
}
