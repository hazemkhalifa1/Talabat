using System.Net;
using System.Net.Mail;

namespace PL.Helpers
{
    public class Email
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
    public static class EmailSetting
    {
        public static void SendEmail(Email email)
        {
            var Client = new SmtpClient("smtp.gmail.com", 587);
            Client.EnableSsl = true;
            Client.Credentials = new NetworkCredential("hazemkhalifa1211@gmail.com", "ncsgiqcgzjxclgon");
            Client.Send("hazemkhalifa1211@gmail.com", email.To, email.Subject, email.Body);
        }
    }
}
