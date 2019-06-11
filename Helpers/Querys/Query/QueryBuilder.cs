using EntityFrameworkMy.Core.Common;
using EntityFrameworkMy.Core.Service;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace EntityFrameworkMy.Helpers.Querys.Query
{
    using Tools.Generela;
    using Querys.Procedures;
    using System.Reflection;

    public class QueryBilder<T> where T : class
    {
        public bool QueryInserter(T entity)
        {
            ProcedureQuery.Insert(entity);
            SqlCommand comm = new SqlCommand(entity.GetType().Name + "_Insert", Connected.Connection);
            comm.CommandType = CommandType.StoredProcedure;
            foreach (var item in entity.GetType().GetProperties())
            {

                if (Tools.FindID(item))
                    continue;
                if (Tools.IsNull(item.GetValue(entity)))
                    comm.Parameters.AddWithValue("@" + item.Name, item.GetValue(entity));
            }
            return Commond.ExecuteQuery(comm);

        }
        public static bool QueryDelete(T entity)
        {
            //string Name = string.Empty;
            //Procedures.Delete(entity);
            //SqlCommand command = new SqlCommand(entity.GetType().Name + "_Delete", Connected.Connection);
            //command.CommandType = CommandType.StoredProcedure;



            //            ;
            //command.Parameters.AddWithValue(Name,1);
            return false;
            //return Commond.ExecuteQuery(command);


        }
        public static void QueryUpdate(T entity, int id)
        {
            ProcedureQuery.Update(entity);

            SqlCommand command = new SqlCommand(entity.GetType().Name + "_Update", Connected.Connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            foreach (PropertyInfo item in entity.GetType().GetProperties())
            {
                if (Tools.FindID(item))
                {
                    item.SetValue(entity, id);
                }

                if (Tools.IsNull(item.GetValue(entity)))
                {
                    command.Parameters.AddWithValue("@" + item.Name, item.GetValue(entity));
                }



            }
            ///return Commond.ExecuteQuery(command);
        }
        public static DataTable QueryList(T obj)
        {
            string name = obj.GetType().Name + "_Select";
            ProcedureQuery.Select(obj);
            SqlDataAdapter adapter = new SqlDataAdapter(name, Connected.Connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;

        }


    }
}
