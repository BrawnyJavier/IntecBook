using System.Net.Mail;
namespace Utilities
{
    public class EmailSender
    {
        public void SendEmail(string EmailBody, string Subject, string Mail)
        {
            MailMessage MailMessage = new MailMessage("intecbook@gmail.com", Mail);
            MailMessage.Subject = Subject;
            MailMessage.Body = EmailBody;
            SmtpClient SmtpClient = new SmtpClient("smtp.gmail.com", 587);
            SmtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "intecbook@gmail.com",
                Password = "todobien22"
            };
            SmtpClient.EnableSsl = true;
            SmtpClient.Send(MailMessage);
        }

    }
}
