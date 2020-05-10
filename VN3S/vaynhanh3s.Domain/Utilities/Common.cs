using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utilities
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

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes( typeof(DescriptionAttribute), false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
