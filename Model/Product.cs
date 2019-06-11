
using EntityFrameworkMy.Core.Attrubite;

namespace EntityFrameworkMy.Model
{
  public  class Product
    {
        [Identity]
        public int ID { get; set; }
        public string Name { get; set; }
        [ForeignKey]
        public Category Category { get; set; }
        public int? CategoryID { get; set; }
    }
}
