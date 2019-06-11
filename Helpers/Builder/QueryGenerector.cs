using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkMy.Helpers.Builder
{
   public class QueryGenerector<T> where T:class
    {
        public static void Delete(string  entity)
        {

            SqlCommand command = new SqlCommand();

        }
    }
}
