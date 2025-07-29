using Company.omar.DAL.Model;
using Company.omar.PLL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Company.omar.PL.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeesController(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository )
        {
            _employeeRepository = employeeRepository;
           _departmentRepository = departmentRepository;
        }
        public IActionResult Index(string? SearchInput)
        {
            IEnumerable<Employee> employees;
            if (!string.IsNullOrEmpty(SearchInput))
            {
                employees = _employeeRepository.SearchByName(SearchInput);
                return View(employees);
            }
             employees = _employeeRepository.GetAll();
            return View(employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var department = _departmentRepository.GetAll();
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
             var count = _employeeRepository.Add(model);
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
            var employee = _employeeRepository.Get(Id);
            if (employee == null) { return BadRequest(new { StatusCode = 404, Message = $"Employee with id {Id} Not fount" }); }
            return View(ViewName,employee);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var department = _departmentRepository.GetAll();
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
             var count = _employeeRepository.Update(employee);
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
                var count = _employeeRepository.Delete(employee);
                if (count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(employee);
        }

    }
}
