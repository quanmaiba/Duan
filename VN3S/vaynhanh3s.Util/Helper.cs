using System;
using System.Linq;
using System.Net.Mail;
using vaynhanh3s.Domain.Request.Email;

namespace vaynhanh3s.Util
{
    public class EmailService
    {
        public EmailService()
        {
        }

        public static bool Send(SendEmailRequest request)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(vaynhanh3sConfig.SenderEmail, vaynhanh3sConfig.SenderPassword),
                    EnableSsl = true
                };

                MailMessage mail = new MailMessage(new MailAddress(vaynhanh3sConfig.SenderEmail, vaynhanh3sConfig.SenderName, System.Text.Encoding.UTF8), new MailAddress(string.IsNullOrWhiteSpace(request.ToEmail) ? vaynhanh3sConfig.SenderEmail : request.ToEmail))
                {
                    Subject = request.subject,
                    Body = request.body,
                    IsBodyHtml = true,
                    DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure,
                    Priority = MailPriority.High,
                    SubjectEncoding = System.Text.Encoding.UTF8
                };

                if (request.AdminEmailList != null && request.AdminEmailList.Any())
                {
                    foreach (var mitem in request.AdminEmailList.Select(c => new MailAddress(c)))
                    {

                        mail.Bcc.Add(mitem);
                    }
                }

                smtpClient.Send(mail);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
