using EntityFrameworkMy.Core;
using EntityFrameworkMy.Helpers.Tools.Generela;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkMy.Core.Procedure
{
    public class DeleteProcedure
    {

        public static string Delete(dynamic entity, string Name = "CREATE")
        {

            string ID = string.Empty;
            PropertyInfo[] info = entity.GetType().GetProperties();
            StringBuilder builder = new StringBuilder();
            builder.Append($"{Name} PROCEDURE ");
            builder.Append(entity.GetType().Name + "_DELETE" + " ");
            foreach (PropertyInfo item in info)
            {
                if (Tools.FindID(item))
                {
                    ID = item.Name;

                }

            }
            builder.Append("@" + ID + "  INTEGER ");
            builder.Append(" AS BEGIN ");
            builder.Append(" DELETE " + entity.GetType().Name + " WHERE " + ID + " = @" + ID);
            builder.Append("  END");
            return builder.ToString();
        }

    }
}
