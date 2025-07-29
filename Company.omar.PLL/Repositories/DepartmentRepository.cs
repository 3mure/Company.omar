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
    public class DepartmentRepository : GenaricRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(APPDbContext context) : base(context)
        {
        }
    }
}
