using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkMy.Exeptions
{
    public class Exseptions : Exception
    {
        public static void NullArgument()
        {
            throw new ArgumentNullException();
        }
        public static void NullReference()
        {
           
            throw new NullReferenceException();
        }
       
    }
}
