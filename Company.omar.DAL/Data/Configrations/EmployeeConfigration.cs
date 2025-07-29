using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.omar.DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.omar.DAL.Data.Configrations
{
    public class EmployeeConfigration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
          builder.Property(e=>e.Id).HasColumnName("EmployeeID").UseIdentityColumn(10,10);
            builder.Property(e => e.Salary).HasColumnType("decimal");
            builder.HasOne(E => E.Department)
                   .WithMany(d => d.Employees)
                   .OnDelete(DeleteBehavior.SetNull)
                   .HasForeignKey(e => e.DepartmentId);

            
        }
    }
}
