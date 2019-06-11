using System.Text;

namespace EntityFrameworkMy.Core.Procedure
{
    public class SelectProcedure
    {
        public static string Select(dynamic entity, string Name = "CREATE")
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"{Name} PROCEDURE ");
            builder.Append(entity.GetType().Name + "_Select" + " \n");
            builder.Append(" AS BEGIN ");
            builder.Append("SELECT * FROM " + entity.GetType().Name);
            builder.Append(" \nEND");
            return builder.ToString();
        }
    }
}
