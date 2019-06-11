using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EntityFrameworkMy.Helpers.Querys.DataBase
{
    using Tools.Generela;
    public class DbQuery<T> where T : class
    {

        public DbQuery()
        {

        }

        private const string ID = " INT PRIMARY KEY IDENTITY (1, 1),";
        private const string Tables = "    CREATE TABLE \n ";
        public static string Table(string name)
        {

            StringBuilder main = new StringBuilder();
            main.Append(" USE " + name + " \n ");
            StringBuilder builder = new StringBuilder();
            StringBuilder subtable = new StringBuilder();
            StringBuilder refe = new StringBuilder();
            List<string> re = new List<string>();



            PropertyInfo[] info = typeof(T).GetProperties();
            builder.Append(Tables + typeof(T).Name + "(\n");
            foreach (PropertyInfo item in info)
            {
                if (Tools.FindID(item))
                {
                    builder.Append(item.Name.ToUpper() + ID);
                    continue;
                }
                if (Tools.ForeignKey(item))
                {

                    subtable.Append(Tools.SubTable(item));
                    refe.Append(Tools.References(item));
                    refe.Append(",");


                }

                if (Tools.ForeignKey(item))
                    continue;
                if (!Tools.NumberType(item))
                {
                    int lenght = Tools.StringLengthAttrubite(item);
                    builder.Append("\n" + item.Name + $" VARCHAR({lenght}) " + ",");
                }


                else if (Tools.isDateTime(item))
                {
                    builder.Append("\n" + item.Name + " datetime " + ",");
                }
                else if (Tools.IsBool(item))
                {
                    builder.Append("\n" + item.Name + " bit " + ",");
                }
                else
                {
                    builder.Append("\n" + item.Name + " INTEGER " + ",");
                }


            }



            if (subtable.Length > 0)
            {


                builder.Append(refe.ToString());
                builder.Remove(builder.Length - 1, 1);

                subtable.Append(builder.ToString());
                string ss = builder.ToString();
                return main.Append(subtable + "  );").ToString();

            }
            builder.Remove(builder.Length - 1, 1);
            builder.Append(" );");
            main.Append(builder);

            return main.ToString();


        }


    }
}
