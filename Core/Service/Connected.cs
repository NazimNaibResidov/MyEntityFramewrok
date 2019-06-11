using EntityFrameworkMy.Helpers.Tools.DataBase;
using System.Configuration;
using System.Data.SqlClient;

namespace EntityFrameworkMy.Core.Service
{
    public  class Connected
    {
        private static SqlConnection connection;
        public static SqlConnection Connection
        {
            get
            {
                string name = Tools.GetDbNameFromFile();
                if (connection == null)

                    connection = new SqlConnection(ConfigurationManager.ConnectionStrings[name].ToString());

                return connection;
            }
            set { connection = value; }
        }
    }
}
