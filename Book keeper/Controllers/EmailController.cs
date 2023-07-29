using Book_keeper.Mail_Services;
using Book_keeper.Models.Mail_Request;
using Microsoft.AspNetCore.Mvc;

namespace Book_keeper.Controllers
{
    [ApiController]
    public class EmailController : Controller
    {
        private readonly IMailService mailService;
        public EmailController( IMailService mailService)
        {
            this.mailService = mailService;
        }
        [HttpGet]
        [Route("send")]
        public Response  Send(string email)
        {
            Response response = new Response();
            try
            {
                MailRequest request = new MailRequest();
                request.ToEmail = email;
                request.Subject = "Book Keeper Email vrification";
                request.Body = "Welcome to Book Keeper!!!\n"+
                "This is an auto-generated email for account verification.\n" +
                "Your account has been created successfully.\n" +
                "Thank You\n" +
                "Team Book Keeper";

                mailService.SendEmailAsync(request);
                response.StatusCode = 200;
                response.StatusMessage = "Email Verified successfully";

            }catch (Exception ex) 
            {
               Console.WriteLine(ex.Message);    
            
            }
            return response;
        }

    }
}
