using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.omar.DAL.Model;

namespace Company.omar.PLL.Interface
{
    public interface IEmployeeRepository:IGenaricRepository<Employee>
    {
        
         List<Employee> SearchByName(string? name);
        // IEnumerable<Employee> GetActiveEmployees();
        // IEnumerable<Employee> GetEmployeesByDepartment(int departmentId);

    }
}
