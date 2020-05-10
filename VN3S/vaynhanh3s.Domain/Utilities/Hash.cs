using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utilities
{
    public static class Hash
    {
        public static string HashString(string inputString, string hashName)
        {
            var algorithm = HashAlgorithm.Create(hashName);
            if (algorithm == null)
            {
                throw new ArgumentException("Unrecognized hash name", "hashName");
            }
            var hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
            return Convert.ToBase64String(hash);
            //return Encoding.UTF8.GetString(hash);
        }

        public static string GetHash(string text, HashType hashType)
        {
            HashAlgorithm algorithm;
            switch (hashType)
            {
                case HashType.MD5:
                    algorithm = MD5.Create();
                    break;
                case HashType.SHA1:
                    algorithm = SHA1.Create();
                    break;
                case HashType.SHA256:
                    algorithm = SHA256.Create();
                    break;
                case HashType.SHA512:
                    algorithm = SHA512.Create();
                    break;
                default:
                    throw new ArgumentException("Invalid hash type", "hashType");
            }
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            byte[] hash = algorithm.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
        public enum HashType : int
        {
            MD5,
            SHA1,
            SHA256,
            SHA512
        }
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        public static async Task<string> SignGenerator(string input)
        {
            var p2 = System.Text.Encoding.Unicode.GetBytes(input);
            System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            var result = sha.ComputeHash(p2);
            //string encodedPassword = Convert.ToBase64String(result);
            var encodedPassword = await Task.Run(() => Convert.ToBase64String(result));
            return encodedPassword;
        }
    }
}
