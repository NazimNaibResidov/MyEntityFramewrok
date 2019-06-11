using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkMy.Core.Attrubite
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed  class ForeignKey : Attribute
    {
    }
}
