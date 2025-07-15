using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.omar.DAL.Data.context;
using Company.omar.DAL.Model;
using Company.omar.PLL.Interface;

namespace Company.omar.PLL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly APPDbContext _context;

        public DepartmentRepository()
        {
         _context = new APPDbContext();
        }

        public Department GetDepartment(int id)
        {
            return _context.Departments.Find(id); 
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }
        public int AddDepartment(Department Modle)
        {
            _context.Departments.Add(Modle);
           return _context.SaveChanges();

        }
        
        public int UpdateDepartment(Department Modle)
        {
            _context.Departments.Update(Modle);
            return _context.SaveChanges();
        }

        public int DeleteDepartment(Department Modle)
        {
            _context.Departments.Remove(Modle);
            return _context.SaveChanges();
        }

       

        

        
    }
}
