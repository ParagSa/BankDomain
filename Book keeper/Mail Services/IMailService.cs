using Book_keeper.Models.Mail_Request;

namespace Book_keeper.Mail_Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
