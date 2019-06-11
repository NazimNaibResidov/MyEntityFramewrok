using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkMy.Core.Procedure
{
    public  class OrderByDescProcedure
    {
        public static void Create(dynamic entity, string Name = "CREATE")
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"{Name} PROCEDURE ");
            builder.Append(entity.GetType().Name + "_Insert" + " ");
        }
    }
}
