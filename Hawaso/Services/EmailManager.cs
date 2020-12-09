using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Hawaso.Services
{
    public class EmailManager : IEmailManager
    {
        private const string REPLY_TO_EMAIL = "devlec@outlook.kr";
        private const string REPLY_TO_NAME = "DevLec";

        public async Task SendEmailAsync(string email, string subject, string message, string recipient = "", string callbackUrl = "")
        {
            var client = new SendGridClient("SG.qAoQNyEZQcm7lh8NaSo-kw.");

            var msg = new SendGridMessage()
            {
                From = new EmailAddress(REPLY_TO_EMAIL, REPLY_TO_NAME),
                Subject = subject,
                PlainTextContent = message,
            };

            msg.AddTo(new EmailAddress(email, recipient));
            var response = await client.SendEmailAsync(msg);
        }

        public async Task SendEmailCodeAsync(string email, string subject, string message, string recipient = "", string callbackUrl = "")
        {
            var client = new SendGridClient("SG.qAoQNyEZQcm7lh8NaSo-kw.");

            var msg = new SendGridMessage()
            {
                From = new EmailAddress(REPLY_TO_EMAIL, REPLY_TO_NAME),
                Subject = subject,
                HtmlContent = message
            };

            msg.AddTo(new EmailAddress(email, recipient));
            var response = await client.SendEmailAsync(msg);
        }
    }
}
