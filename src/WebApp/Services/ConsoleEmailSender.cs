using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Web;

namespace WebApp.Services
{
    public class ConsoleEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            System.Console.WriteLine("---New Email----");
            System.Console.WriteLine($"To: {email}");
            System.Console.WriteLine($"Subject: {subject}");
            System.Console.WriteLine(HttpUtility.HtmlDecode(htmlMessage));
            System.Console.WriteLine("-------");
            return Task.CompletedTask;
        }
    }
}
