using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorsForms
{
    internal class CamelCase
    {
        public static string GetClassName(string tableName)
        {
            string ret = tableName.ToUpper()[0] + tableName.Substring(1,tableName.Length-2);            
            return ret;
        }
    }
}
