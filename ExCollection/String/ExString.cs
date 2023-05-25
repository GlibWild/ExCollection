using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.Json;

namespace ExCollection
{
    public static class ExString
    {
        public static string ToFirstCharLower(this string str) 
        {
            if(string.IsNullOrEmpty(str)) return str;
            str = str.Substring(0,1).ToLower()+str.Substring(1);
            return str;
        }
        public static string ToFirstCharUpper(this string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            str = str.Substring(0, 1).ToUpper() + str.Substring(1);
            return str;
        }
    }
}
