using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TDSBackend.DocumentCleaning
{
    public static class StringCleaner
    {

        public static string clean(string file)
        {
            file = System.Text.RegularExpressions.Regex.Replace(file, @"\s+", " ");
            file = System.Text.RegularExpressions.Regex.Replace(file, @"[^\w\s]", "");
            return file.ToLower();
        }
    }
}
