using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public static class HelpClass
    {
        // Help methods
        public static string MySubString(string source, int start, int end)
        {
            string result = "";
            for (int i = start; i < end; i++)
            {
                result += source[i];
            }
            return result;
        }
    }
}
