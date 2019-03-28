using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelHelperProject.Commons
{
    public static class ExtensionMethod
    {
        public static bool Contains(this string source, string check, StringComparison stringComparison)
        {
            return source?.IndexOf(check, stringComparison) >= 0;
        }
    }
}
