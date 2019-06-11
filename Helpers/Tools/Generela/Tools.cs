using EntityFrameworkMy.Core.Attrubite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Data.SqlClient;
namespace EntityFrameworkMy.Helpers.Tools.Generela
{
    using DataBase;
    

    public class Tools
    {
        public static Type GetSubclasses(Type type, bool ignoreSystem)
        {
            Type Return = null;
            foreach (var a in System.Threading.Thread.GetDomain().GetAssemblies())
            {
                if (ignoreSystem && a.FullName.StartsWith("System."))
                {
                    continue;
                }
                foreach (var t in a.GetTypes())
                {
                    if (t.IsSubclassOf(type) || (type.IsInterface && t.GetInterfaces().FirstOrDefault(e => e.FullName == type.FullName) != null))
                    {
                        Return = t;
                    }
                }
            }
            return Return;

        }
        public static bool IsNull(object obj)
        {

            if (obj != null)
            {
                var data = obj.GetType();
                if (data.Name == "Boolean")
                {

                    return Convert.ToBoolean(obj) == true ? true : false;
                }
            }
            return obj != null ? true : false;

        }
        public static void CreateObject(Type subClass, Type[] tip)
        {

            Object(subClass, tip);
        }
        private static List<Type> GSCP(Type type)
        {
            List<Type> tip = new List<Type>();
            Assembly myAssembly = Assembly.GetExecutingAssembly();



            foreach (var item in type.GetProperties())
            {
                object ob = item.PropertyType.GetType();
                var k = item.SetMethod;
                var p = item.MemberType;
                var ss = (Type)myAssembly.DefinedTypes.FirstOrDefault(x => x.Name.ToUpper() == item.Name.ToUpper());
                tip.Add(ss);
            }
            return tip;
        }
        private static object Object(Type sublass, Type[] fist)
        {
            return new object();


        }
        public static void InsertSubQuery(dynamic entity, SqlCommand command)
        {
            foreach (var item in entity.GetType().GetProperties())
            {

                if (Tools.FindID(item))
                    continue;
                if (Tools.IsNull(item.GetValue(entity)))
                    command.Parameters.AddWithValue("@" + item.Name, item.GetValue(entity));


            }
        }
        public static string GetName(object entity)
        {
            return entity.GetType().Name.ToString();
        }
        public static bool FindID(PropertyInfo item)
        {

            var data = item.GetCustomAttributes(typeof(Identity), true);
            if (data.Length > 0 || item.Name.ToUpper() == "ID")
            {
                return true;
            }
            return false;





        }
        public static int StringLengthAttrubite(PropertyInfo info)
        {

            int leng = 100;
            Attribute attribute = info.GetCustomAttribute(typeof(StringLeng), true);
            if (attribute is StringLeng)
            {
                leng = 0;
                leng = (attribute as StringLeng).Lenght;
            }
            return leng;

        }
        public static void TrimComma(StringBuilder biler)
        {
            biler.Remove(biler.Length - 1, 1);
        }
        public static void GetName(object entity, StringBuilder bilder)
        {
            foreach (var item in entity.GetType().GetProperties())
            {
                if (FindID(item))
                    continue;
                if (IsNull(item.GetValue(entity)))
                    bilder.Append(item.Name + " ,");

            }
        }
        public static void ValueInserted(dynamic entity, StringBuilder bilder)
        {
            foreach (var item in entity.GetType().GetProperties())
            {

                if (FindID(item))
                    continue;
                if (IsNull(item.GetValue(entity)))
                    bilder.Append("@" + item.Name + " ,");

            }
        }
        public static bool NumberType(PropertyInfo info)
        {

            return
 info.PropertyType == typeof(int) ||
 info.PropertyType == typeof(int?) ||
 info.PropertyType == typeof(byte) ||
 info.PropertyType == typeof(byte?) ||
 info.PropertyType == typeof(sbyte) ||
 info.PropertyType == typeof(sbyte?) ||
 info.PropertyType == typeof(long) ||
 info.PropertyType == typeof(long?) ||
 info.PropertyType == typeof(bool) ||
 info.PropertyType == typeof(bool?) ||
 info.PropertyType == typeof(decimal) ||
 info.PropertyType == typeof(decimal?) ||
 info.PropertyType == typeof(short) ||
 info.PropertyType == typeof(short?) ||
 info.PropertyType == typeof(double?) ||
 info.PropertyType == typeof(double);



        }
        public static bool PropertTypes(PropertyInfo info, string name)
        {
            return info.PropertyType.Name.ToLower() == name.ToLower() ? true : false;

        }
        public static bool IsClassed(PropertyInfo info)
        {
            var data = info;
            return info.PropertyType.IsClass ? true : false;
        }
        public static bool ForeignKey(PropertyInfo info)
        {
            var data = info.GetCustomAttributes(typeof(ForeignKey), true);
            if (data.Length > 0)
            {
                return true;
            }
            return false;

        }
        public static int atrubiteCount<T>()
        {
            var data = typeof(T).GetCustomAttributes(typeof(ForeignKey), true);
            return data.Length;
        }
        public static string References(PropertyInfo perop)
        {

            string id = "id";
            StringBuilder builder = new StringBuilder();

            builder.Append(" FOREIGN KEY ( " + perop.PropertyType.Name + $"{id.ToUpper()}) ");
            builder.Append(" REFERENCES " + perop.PropertyType.Name + " ( ");
            var data = perop.PropertyType;
            var s = data.GetProperties();
            foreach (var item in s)
            {

                if (FindID(item))
                {
                    builder.Append(item.Name + ")");
                }
            }

            return builder.ToString();
        }
        public static string SubTable(PropertyInfo perop)
        {

            if (DataBase.Tools.IsTableExisting(perop.Name))
            {
                StringBuilder builder = new StringBuilder();

                builder.Append(" CREATE TABLE " + perop.PropertyType.Name + "(\n");

                var data = perop.PropertyType;
                var s = data.GetProperties();
                foreach (var item in s)
                {
                    if (FindID(item))
                    {
                        builder.Append(item.Name.ToUpper() + " INT PRIMARY KEY IDENTITY(1, 1),");
                        continue;
                    }
                    if (ForeignKey(item))
                    {

                        continue;
                    }


                    if (!NumberType(item))
                    {
                        int lenght = StringLengthAttrubite(item);
                        builder.Append("\n" + item.Name + $" VARCHAR({lenght}) " + ",");
                    }


                    else if (isDateTime(item))
                    {
                        builder.Append(" \n " + item.Name + " datetime " + ",");
                    }
                    else if (IsBool(item))
                    {
                        builder.Append(" \n " + item.Name + " bit " + ",");
                    }
                    else
                    {
                        builder.Append("\n" + item.Name + " INTEGER " + ",");
                    }
                }
                builder.Remove(builder.Length - 1, 1);
                builder.Append("  ); \n ");
                return builder.ToString();
            }
            return " ";





        }
        public static bool isDateTime(PropertyInfo info)
        {
            return info.PropertyType == typeof(DateTime) ? true : false;
        }
        public static bool IsBool(PropertyInfo info)
        {
            if (info.PropertyType == typeof(bool))
            {
                return true;
            }
            return false;
        }
        public static string GetDbNameFromFile()
        {
            return File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "connection.txt"));
        }
        public static bool IsIfId(PropertyInfo info)
        {
            return info.Name.ToUpper() == "ID" ? true : false;

        }
        private static PropertyInfo GetProperty<T>(T entity)
        {
            PropertyInfo info = null;
            foreach (var item in entity.GetType().GetProperties())
            {
                info = item;
            }
            return info;
        }




    }
}
