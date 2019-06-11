using EntityFrameworkMy.Helpers.Tools.DataBase;

namespace EntityFrameworkMy.Database
{
    public abstract class DbContext
    {
        public DbContext(string name)
        {
              Tools.Database(name);
              Creater();
           
       }
        public abstract void Creater();

        
   }
}
