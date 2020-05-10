using System.Collections.Generic;
using System.IO;

namespace vaynhanh3s.Domain.Request.Email
{
    public class SendEmailRequest
    {
        public string subject { get; set; }
        public string body { get; set; }
        public string ToEmail { get; set; }
        public string template { get; set; }
        public List<string> AdminEmailList { get; set; }
    }

    public static class EmailTemplate
    {
        public static string MacDinh = $@"Views\EmailTemplates\MacDinh.cshtml";
        public static string QuenMatKhau = $@"Views\EmailTemplates\QuenMatKhau.cshtml";
    }
}
