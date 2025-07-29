using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.omar.DAL.Model;

namespace Company.omar.PLL.Interface
{
    public interface IGenaricRepository<T> where T: BaseEntity
    {
        IEnumerable<T> GetAll();
        T? Get(int? id);
        int Add(T Modle);
        int Update(T Modle);
        int Delete(T Modle);
    }
}
