using Book_keeper.Models.Mail_Request;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Book_keeper.Mail_Services
{
    public class MailService : IMailService
    {
        private readonly Settings.MailSettings _settings;
        public MailService(IOptions<Settings.MailSettings> mailSettings) 
        { 
            _settings = mailSettings.Value; 
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_settings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();

            builder.HtmlBody = mailRequest.Body;    
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_settings.Host,_settings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_settings.Mail,_settings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
