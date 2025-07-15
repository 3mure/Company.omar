using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.omar.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace Company.omar.DAL.Data.Configrations
{
    internal class DepartmentConfigration : IEntityTypeConfiguration<Department>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Department> builder)
        {
           builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).HasColumnName("DepartmentId").UseIdentityColumn(10,10);

            builder.Property(D=> D.code)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(d => d.Name)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnName("DepartmentName");
            builder.Property(d => d.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("getdate()");



        }
    }
}
