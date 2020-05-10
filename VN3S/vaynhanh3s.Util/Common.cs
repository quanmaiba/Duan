using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace vaynhanh3s.Util
{
    public class Common
    {
        public static string RandomString(int length)
        {
            var random = new Random();
            const string chars = "abcdefghijkmnpqrstuvwxyz123456789ABCDEFGHJKLMNPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public async static Task<string> CreateSign(long ContactId, string CurrentDatetime, string DeviceID, string Token, string email)
        {
            var inputS = string.Format("{0}{1}{2}{3}{4}", ContactId, DeviceID, Token, CurrentDatetime, email.ToLower().Trim());
            return await Hash.SignGenerator(inputS);
        }
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static class GenerateVydioToken
        {
            private const long EPOCH_SECONDS = 62167219200;

            public static string Generate(string key, string appID, string userName, long expiresInSecs, string expiresAt)
            {
                string delimStr = "=";
                char[] delimiter = delimStr.ToCharArray();

                if ((appID != null) && (key != null) && (userName != null))
                {
                    string expires = "";

                    // Check if using expiresInSecs or expiresAt
                    if (expiresInSecs > 0)
                    {
                        TimeSpan timeSinceEpoch = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0));
                        expires = (Math.Floor(timeSinceEpoch.TotalSeconds) + EPOCH_SECONDS + expiresInSecs).ToString();
                    }
                    else if (expiresAt != null)
                    {
                        try
                        {
                            TimeSpan epochToExpires = DateTime.Parse(expiresAt).ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0));
                            expires = (Math.Floor(epochToExpires.TotalSeconds) + EPOCH_SECONDS).ToString();
                        }
                        catch (Exception e)
                        {
                            return "";
                        }
                    }
                    else
                    {
                        return "";
                    }

                    string jid = userName + "@" + appID;
                    string body = "provision" + "\0" + jid + "\0" + expires + "\0" + "";

                    var encoder = new UTF8Encoding();
                    var hmacsha = new HMACSHA384(encoder.GetBytes(key));
                    byte[] mac = hmacsha.ComputeHash(encoder.GetBytes(body));

                    // macBase64 can be used for debugging
                    //string macBase64 = Convert.ToBase64String(hashmessage);

                    // Get the hex version of the mac
                    string macHex = BytesToHex(mac);

                    string serialized = body + '\0' + macHex;

                    return Convert.ToBase64String(encoder.GetBytes(serialized));
                }
                return "";
            }
            private static string BytesToHex(byte[] bytes)
            {
                var hex = new StringBuilder(bytes.Length * 2);
                foreach (byte b in bytes)
                {
                    hex.AppendFormat("{0:x2}", b);
                }
                return hex.ToString();
            }
        }

        public static class EncryptUserId
        {
            public static readonly string Alphabet = @"abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            public static string Encode(long userId)
            {
                var result = string.Empty;
                ulong value = 0;

                if (userId > 0)
                {
                    value += (ulong) BcPow(Alphabet.Length, userId);
                }

                for (var t = (value != 0 ? Math.Floor(Math.Log(value, Alphabet.Length)) : 0); t >= 0; t--)
                {
                    var bcp = (ulong) BcPow(Alphabet.Length, t);
                    var a = ((ulong) Math.Floor((decimal) value / (decimal) bcp)) % (ulong)Alphabet.Length;
                    result += Alphabet[(int) a];
                    value = value - (a * bcp);
                }

                return ReverseString(result);
            }

            public static ulong Decode(string value, long pad = 0)
            {
                value = ReverseString(value);
                var len = value.Length - 1;
                ulong result = 0;

                for (int t = len; t >= 0; t--)
                {
                    var bcp = (ulong) BcPow(Alphabet.Length, len - t);
                    result += (ulong) Alphabet.IndexOf(value[t]) * bcp;
                }

                if (pad > 0)
                {
                    result -= (ulong) BcPow(Alphabet.Length, pad);
                }

                return result;
            }

            private static string ReverseString(string value)
            {
                char[] arr = value.ToCharArray();
                Array.Reverse(arr);
                return new string(arr);
            }

            private static decimal BcPow(double a, double b)
            {
                return Math.Floor((decimal) Math.Pow(a, b));
            }
        }
    }
}