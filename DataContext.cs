using EntityFrameworkMy.Database;
using EntityFrameworkMy.Model;

namespace EntityFrameworkMy.Wind.UI
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Main")
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Cateogry { get; set; }
        public DbSet<Image> Image { get; set; }
        public override void Creater()
        {
            Image = new DbSet<Image>();
            Cateogry = new DbSet<Category>();
            Product = new DbSet<Product>();
        }

    }
}
