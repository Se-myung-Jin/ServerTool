using System.Security.Cryptography;
using System.Text;

namespace ServerTool
{
    public static class EncodingManager
    {
        private static string ComputeMd5Hash(string message)
        {
            MD5 md5 = MD5.Create();
            byte[] input = Encoding.ASCII.GetBytes(message);
            byte[] hash = md5.ComputeHash(input);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        private static string SHA256Hash(string data)
        {
            SHA256 sha = new SHA256Managed();
            byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(data));
            StringBuilder stringBuilder = new StringBuilder();

            foreach (byte b in hash)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }

            return stringBuilder.ToString();
        }

        public static string Encrypt(string password)
        {
            var md5Password = ComputeMd5Hash(password);

            return SHA256Hash(md5Password);
        }
    }
}
