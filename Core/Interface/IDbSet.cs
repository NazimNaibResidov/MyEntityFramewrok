using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkMy.Core.Interface
{
  public  interface IDbSet<T> where T:class
    {
        List<T> Listle();
        bool Delete(T entity);
        bool Insert(T entity);
        bool Update(T entity);
    }
}
