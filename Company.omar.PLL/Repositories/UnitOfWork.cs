using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.omar.DAL.Data.context;
using Company.omar.PLL.Interface;

namespace Company.omar.PLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly APPDbContext _context;

        public IEmployeeRepository employeeRepository { get; }

        public IDepartmentRepository departmentRepository { get; }

        public int SaveChanges()
        {
          return  _context.SaveChanges();
        }

        public void Dispose()
        {
           _context.Dispose();
        }

        public UnitOfWork(APPDbContext context )
        {
            employeeRepository = new EmployeeRepository(_context);
            departmentRepository = new DepartmentRepository(_context);
            _context = context;
        }
    }
}
