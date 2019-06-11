using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkMy.Core.Attrubite
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed  class StringLeng : Attribute
    {
        public int Lenght { get; set; }
        public StringLeng(int Lenght)
        {
            this.Lenght = Lenght;

        }
    }
}
