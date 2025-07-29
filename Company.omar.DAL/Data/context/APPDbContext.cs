using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Company.omar.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace Company.omar.DAL.Data.context
{
    public class APPDbContext : DbContext
    {
        public APPDbContext(DbContextOptions<APPDbContext> options) : base(options)
        {
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer("Server=.;Database=Company.omar; Trusted_Connection=True;TrustServerCertificate = True");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            base.OnModelCreating(modelBuilder);
        }
         public DbSet<Department> Departments { get; set; }
         public DbSet<Employee> Employees { get; set; }
    }
}
