using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.omar.DAL.Data.context;
using Company.omar.DAL.Model;
using Company.omar.PLL.Interface;
using Microsoft.EntityFrameworkCore;

namespace Company.omar.PLL.Repositories
{
    public class EmployeeRepository : GenaricRepository<Employee>, IEmployeeRepository
    {
        private readonly APPDbContext _context;

        public EmployeeRepository(APPDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Employee> SearchByName(string? name)
        {
            _context.ChangeTracker.Clear();
            if (string.IsNullOrEmpty(name))
            {
                return _context.Employees.Include(e => e.Department).ToList();
            }
            else
            {
             return _context.Employees.Include(e=>e.Department)
                            .Where(E=>E.Name.ToLower().Contains(name.ToLower())).ToList();

            }
        }
    }
}
