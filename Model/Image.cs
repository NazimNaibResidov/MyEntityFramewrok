
using EntityFrameworkMy.Core.Attrubite;

namespace EntityFrameworkMy.Model
{
    public class Image
    {
        public int Id { get; set; }
        [StringLeng(200)]
        public string Name { get; set; }
        [ForeignKey]
        public Category Category { get; set; }
        public int? CategoryID { get; set; }
    }
}
