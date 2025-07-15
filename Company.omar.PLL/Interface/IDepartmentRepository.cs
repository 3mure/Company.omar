using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.omar.DAL.Model;

namespace Company.omar.PLL.Interface
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();
        Department GetDepartment(int id);
        int AddDepartment(Department Modle);
        int UpdateDepartment(Department Modle);
        int DeleteDepartment(Department Modle);

    }
}
