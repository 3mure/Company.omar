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
    public class GenaricRepository<T> : IGenaricRepository<T> where T : BaseEntity
    {
        private readonly APPDbContext _context;

        public GenaricRepository(APPDbContext context)
        {
            _context = context;
        }
        public void Add(T Modle)
        {
           _context.Set<T>().Add(Modle);
           
        }

        public void Delete(T Modle)
        {
            _context.Set<T>().Remove(Modle);
            
        }

        //public T? Get(int? id)
        //{
        //    return _context.Set<T>().Find(id.Value);
        //}

        public T? Get(int? id)
        {

            if (typeof(T) == typeof(Employee))
            {
                return _context.Employees.Include(e => e.Department).FirstOrDefault(e=>e.Id==id) as T ;
            }

            return _context.Set<T>().Find(id.Value);
        }

        public IEnumerable<T> GetAll()
        {

            if (typeof(T) == typeof(Employee))
            {
                return (IEnumerable<T>)_context.Employees.Include(e=>e.Department).ToList();
            }

            return _context.Set<T>().ToList();

        }

        public void Update(T Modle)
        {
            _context.Set<T>().Update(Modle);
        }
    }
}
