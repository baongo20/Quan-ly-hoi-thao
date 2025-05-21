using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Do_An.Utils
{
    public class PasswordUtil
    {
        // Create a string MD5
        public static string GetMD5(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty; // hoặc throw exception nếu bạn muốn

            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(str);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }
    }
}