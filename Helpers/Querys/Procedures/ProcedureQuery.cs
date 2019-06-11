using EntityFrameworkMy.Core.Procedure;
using System.Data.SqlClient;


namespace EntityFrameworkMy.Helpers.Querys.Procedures
{
    using EntityFrameworkMy.Core.Common;
    using EntityFrameworkMy.Core.Service;
    using Tools.Procedure; 
   public class ProcedureQuery
    {
      
        public static void Insert(dynamic dynamic)
        {


            var query = InsertProcedure.Insert(dynamic, "Create");
            var data = commoned(dynamic, query);
            if (data == false)
            {
                Tools.ReCreateProcedureIfInsertExists(dynamic);
            }

        }
        public static void Delete(dynamic dynamic)
        {


            var query = DeleteProcedure.Delete(dynamic, "Create");
            var data = commoned(dynamic, query);
            if (data == false)
            {
                
                Tools.ReCreateProcedureIfDeleteExists(dynamic);
            }
        }
        public static void Update(dynamic dynamic)
        {
            var query = UpdateProcedure.Update(dynamic);
            var data = commoned(dynamic, query);
            if (data == false)
            {
                Tools.ReCreateProcedureIfUpdateExists(dynamic);
            }
        }
        public static void Select(dynamic dynamic)
        {
            var query = SelectProcedure.Select(dynamic);
            var data = commoned(dynamic, query);
            if (data == false)
            {
                Tools.ReCreateProcedureIfSelectExists(dynamic);
            }
        }
        private static bool commoned(dynamic dynamic, string query)
        {
            SqlCommand command = new SqlCommand("", Connected.Connection);
            return Commond.ExecuteQueryForText(command, query);
        }
    }
}
