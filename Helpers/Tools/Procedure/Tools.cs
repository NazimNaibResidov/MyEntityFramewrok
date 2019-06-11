using EntityFrameworkMy.Core.Common;
using EntityFrameworkMy.Core.Procedure;
using EntityFrameworkMy.Core.Service;
using System.Data.SqlClient;

namespace EntityFrameworkMy.Helpers.Tools.Procedure
{
    public class Tools
    {
        public static void ReCreateProcedureIfInsertExists(dynamic dynamic)
        {

            SqlCommand command = new SqlCommand("", Connected.Connection);
            var query = InsertProcedure.Insert(dynamic, "ALTER");
            Commond.ExecuteQueryForText(command, query);



        }
        public static void ReCreateProcedureIfDeleteExists(dynamic dynamic)
        {
            SqlCommand command = new SqlCommand("", Connected.Connection);
            var query = DeleteProcedure.Delete(dynamic, "ALTER");
            Commond.ExecuteQueryForText(command, query);

        }
        public static void ReCreateProcedureIfUpdateExists(dynamic dynamic)
        {
            SqlCommand command = new SqlCommand("", Connected.Connection);
            var query = UpdateProcedure.Update(dynamic, "ALTER");
            Commond.ExecuteQueryForText(command, query);

        }
        public static void ReCreateProcedureIfSelectExists(dynamic dynamic)
        {
            SqlCommand command = new SqlCommand("", Connected.Connection);
            var query = SelectProcedure.Select(dynamic, "ALTER");
            Commond.ExecuteQueryForText(command, query);

        }
    }
}
