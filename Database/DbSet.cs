using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using EntityFrameworkMy.Helpers.Querys.Query;
using EntityFrameworkMy.Helpers.Tools.DataBase;
using System.Data.SqlClient;
using EntityFrameworkMy.Core.Service;
using EntityFrameworkMy.Core.Common;

namespace EntityFrameworkMy.Database
{
    public class DbSet<T>where T:class
    {

        private readonly QueryBilder<T> bilder;

        public DbSet()
        {
           
            if(Tools.IsTableExisting(typeof(T).Name))
               Tools.CreateTable<T>(Tools.GetDbNameFromFile());
            bilder = new QueryBilder<T>();
       

        }
       
        public bool Insert(T entity)
        {

            return false;
        }
        
        public bool InsertWithProc(T entity)
        {
          return bilder.QueryInserter(entity);
        }
       
        public  bool Delete(Expression<Func<T,bool>> expression)
        {
             Expression x= expression.Body;
           var h= x.ToString().Split(new char[] { '=' });
           var name= h[0].TrimStart(new char[] { '(', 'x', '.' });
           var tt= h[2].Replace('"',' ').TrimEnd(new char[] { ')' });

            var t= x.ToString();
            var xx = t.TrimStart(new char[] { '(', 'x', '.' }).TrimEnd(new char[] { ')' });
            
            var sx = xx.Replace("==", "=").Replace('"', ' ').ToString();
            var Name = typeof(T).Name;
            StringBuilder builder = new StringBuilder();
            builder.Append($"DELETE  {Name} WHERE {name}=@{name}");
            string query = builder.ToString();
            SqlCommand command = new SqlCommand(query, Connected.Connection);
            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.AddWithValue($"@{name}",tt);

            Commond.ExecuteQuery(command);

            return false;
        }

        public List<T> Listle()
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }
       
    }
}
