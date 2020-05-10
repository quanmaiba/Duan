using LBH.Common.Configuration;

namespace vaynhanh3s.Util
{
    public class vaynhanh3sConfig : BaseConfiguration
    {
        public const string ApplicationEndpointKey = "vaynhanh3s";


        public class ServiceBus
        {
            public static string ConnString => ReadConfigureStringValue("ServiceBusConnectionString");
        }
        public static string vaynhanh3sDBName => ReadConfigureStringValue("vaynhanh3sDBName", "vaynhanh3sConnStr");

        public static string vaynhanh3sConnStr => BaseConfiguration.ReadConnectionStrValue(vaynhanh3sDBName);

        public static string SenderEmail => ReadConfigureStringValue("SenderEmail", "");
        public static string ReceiverEmail => ReadConfigureStringValue("ReceiverEmail", "");
        public static string Username => ReadConfigureStringValue("Username", "");
        public static string Password => ReadConfigureStringValue("Password", "");
        public static string Hotline => ReadConfigureStringValue("Hotline", "");
        public static string Support1 => ReadConfigureStringValue("Support1", "");
        public static string Support2 => ReadConfigureStringValue("Support2", "");
        public static string VayNhanh => ReadConfigureStringValue("VayNhanh", "");
        public static string SenderPassword => ReadConfigureStringValue("SenderPassword", "");
        public static string SenderName => ReadConfigureStringValue("SenderName", "Vay Nhanh 3S");
        public static string AllowDisplay => ReadConfigureStringValue("AllowDisplay", "false");
        public static string GSecretKey => ReadConfigureStringValue("GSecretKey", "6Le_zJgUAAAAABYFr9Isfd9X181fBI1kyYy2n3Ok");
        public static string GoogleAPI => ReadConfigureStringValue("GoogleAPI" , "https://www.google.com/recaptcha/api/siteverify?secret={0}&amp;response={1}");
        public static string EnableCaptcha => ReadConfigureStringValue("EnableCaptch", "false");
    }
}