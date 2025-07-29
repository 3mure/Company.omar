using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.omar.PLL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        public IEmployeeRepository employeeRepository { get; }
        public IDepartmentRepository departmentRepository { get; }
        public int SaveChanges();

    }
}
