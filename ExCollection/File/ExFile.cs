using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ExCollection
{
    public static class ExFile
    {
        public static string GetCheckCodeFromFile(this string filePath, CheckCodeType codeType)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(filePath))
            {
                if (File.Exists(filePath))
                {
                    FileStream fs = new FileStream(filePath, FileMode.Open);
                    result = GetCheckCodeFromFile(fs, codeType);
                }
            }
            return result;
        }

        private static string GetCheckCodeFromFile(this FileStream file, CheckCodeType codeType = CheckCodeType.MD5)
        {
            string result = string.Empty;
            switch (codeType)
            {
                case CheckCodeType.MD5:
                    {
                        var md5 = new MD5CryptoServiceProvider();
                        var bytes = md5.ComputeHash(file);
                        file.Close();
                        result = bytes.ToHexString();
                    }
                    break;
                case CheckCodeType.SHA1:
                    {
                        var sha1 = SHA1.Create();
                        var bytes = sha1.ComputeHash(file);
                        file.Close();
                        result = bytes.ToHexString();
                    }
                    break;
                case CheckCodeType.SHA256:
                    {
                        var sha1 = SHA256.Create();
                        var bytes = sha1.ComputeHash(file);
                        file.Close();
                        result = bytes.ToHexString();
                    }
                    break;
                case CheckCodeType.SHA384:
                    {
                        var sha1 = SHA384.Create();
                        var bytes = sha1.ComputeHash(file);
                        file.Close();
                        result = bytes.ToHexString();
                    }
                    break;
                case CheckCodeType.SHA512:
                    {
                        var sha1 = SHA512.Create();
                        var bytes = sha1.ComputeHash(file);
                        file.Close();
                        result = bytes.ToHexString();
                    }
                    break;
            }
            return result;
        }
    }
    public enum CheckCodeType
    {
        MD5,
        SHA1,
        SHA256,
        SHA384,
        SHA512
    }
}
