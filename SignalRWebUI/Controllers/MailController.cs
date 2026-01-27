using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.Dtos.MailDtos;

namespace SignalRWebUI.Controllers
{
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateMailDto dto)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddress = new MailboxAddress("SignalR Rezervasyon","ztrk1212@gmail.com");
            mimeMessage.From.Add(mailboxAddress);

            MailboxAddress mailboxAddressto = new MailboxAddress("User", dto.RecieverMail);
            mimeMessage.To.Add(mailboxAddressto);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = dto.Body;
            mimeMessage.Body= bodyBuilder.ToMessageBody();

            mimeMessage.Subject = dto.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com",587,false);
            client.Authenticate("ztrk1212@gmail.com", "kjvh qdzf vjwu geya");
            
            client.Send(mimeMessage);
            client.Disconnect(true);
            
            return RedirectToAction("Index","Category");
        }
    }
}
