using EntityFrameworkMy.Core.Common;
using EntityFrameworkMy.Core.Service;
using EntityFrameworkMy.Helpers.Querys.DataBase;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace EntityFrameworkMy.Helpers.Tools.DataBase
{
    public class Tools
    {
        private static void WriteDbNameToFile(string name)
        {
            File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "connection.txt"));
            File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "connection.txt"), name);

        }
        public static string GetDbNameFromFile()
        {
            return File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "connection.txt"));
        }
        public static void Database(string name)
        {

            string conn = "Server=.;Initial Catalog=master;Integrated Security=True";
            SqlConnection Connection = new SqlConnection(conn);
            string query = $"CREATE DATABASE {name} ";
            SqlCommand command = new SqlCommand(query, Connection);
            command.CommandType = CommandType.Text;
            Commond.ExecuteQueryForText(command);
            WriteDbNameToFile(name);




        }
        public static bool CreateTable<T>(string name) where T : class
        {

            SqlConnection sqlConnection = new SqlConnection($"Data Source=.;Initial Catalog={name};Integrated Security=True");
            var quers = DbQuery<T>.Table(GetDbNameFromFile());

            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = quers;
            return Commond.ExecuteQueryForText(command);

        }
        public static bool IsTableExisting(string table)
        {
            string sql = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '" + table + "'";

            SqlCommand sqlCommand = new SqlCommand(sql, Connected.Connection);
            int a = Commond.TableExisitIf(sqlCommand);
            return a > 0 ? false : true;
        }
        private static bool IsDatabaseExisting()
        {

            string databaseName = GetDbNameFromFile();

            string connString = "Server=.;Initial Catalog=master;Integrated Security=True";

            string cmdText = $"select * from master.dbo.sysdatabases where name=\'{databaseName}\'";

            bool bRet = false;

            using (SqlConnection sqlConnection = new SqlConnection(connString))

            {

                sqlConnection.Open();

                using (SqlCommand sqlCmd = new SqlCommand(cmdText, sqlConnection))

                {

                    int nRet = sqlCmd.ExecuteNonQuery();



                    if (nRet <= 0)

                    {

                        bRet = false;

                    }

                    else

                    {

                        bRet = true;

                    }

                }

            }



            return bRet;


        }
    }
}
