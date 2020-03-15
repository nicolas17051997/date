using System;
using System.Collections.Generic;
using System.Text;

namespace DataRange.DAL.Helper
{
   public static class CreateHash
    {
        public static string GetHashString(string s)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            byte[] byteHash = GetHash(bytes);

            string hash = Convert.ToBase64String(byteHash);

            return hash;
        }
        private static byte[] GetHash(byte[] bytes)
        {
            using (var sha = System.Security.Cryptography.SHA1.Create())
            {
                var hash = sha.ComputeHash(bytes);
                return hash;
            }
        }
    }
}
