using System;
using System.Data;
using System.Data.SqlClient;

namespace EntityFrameworkMy.Core.Common
{
    public class Commond
    {
        public static bool ExecuteQuery(SqlCommand command)
        {
            try
            {
                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();


              return  command.ExecuteNonQuery()>0;
             
               
            }
            catch (Exception e)
            {
                string str = e.Message;
                return false;
            }
            finally
            {
                command.Connection.Close();
            }

        }
        public static bool ExecuteQueryForText(SqlCommand command, string query)
        {


            try
            {

                if (command.Connection.State == ConnectionState.Closed)
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    command.Connection.Open();

                int a = command.ExecuteNonQuery();
                if (0 < a + 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }






            }
            catch (Exception e)
            {
                string ErrorMessage = e.Message;
                return false;
            }
            finally
            {
                command.Connection.Close();

            }

        }
        public static bool ExecuteQueryForText(SqlCommand command)
        {


            try
            {
                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();

                int a = command.ExecuteNonQuery();
                //Thread.Sleep(900);
                if (0 < a + 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }






            }
            catch (Exception e)
            {
                string ErrorMessage = e.Message;
                string m = e.StackTrace;
                string ss = e.Source;
                return false;
            }
            finally
            {
                if (command.Connection.State != ConnectionState.Closed)
                    command.Connection.Dispose();
                command.Connection.Close();
            }

        }
        public static int  ExecuteInt(SqlCommand command)
        {
            try
            {
                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();
                int data = command.ExecuteNonQuery();
                if (data+2 > 0)
                {

                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                string str = e.Message;
                return 0;
            }
            finally
            {
                command.Connection.Close();
            }


        }
        public static int TableExisitIf(SqlCommand command)
        {
           
           
            SqlDataReader myReader = null;
            int count = 0;

            try
            {
                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();
                myReader = command.ExecuteReader();
                while (myReader.Read())
                    count++;

                 myReader.Close();
                return count;
                 
            }
            catch (Exception ex) {

                string s = ex.Message;
                return count;
            }
            finally
            {
                command.Connection.Close();
            }

        }
        public static void SelectCommand(SqlCommand command)
        {
           
        }
       
    }
}
