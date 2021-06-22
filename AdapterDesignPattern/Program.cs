using System;

namespace AdapterDesignPattern
{
    class Program
    {
        interface IEmailSender
        {
            public void SendEmail(string clientEmail, string subject, string content);
        }
        class GmailEmailSender : IEmailSender
        {
            public void SendEmail(string clientEmail, string subject, string content)
            {
                // gmail configuration and logic ...

                Console.WriteLine($"Sending email via Gmail throw SMTP protocol...");
                Console.WriteLine($"To: {clientEmail}");
                Console.WriteLine($"Subject: {subject}");
                Console.WriteLine($"Content: {content}");
            }
        }
        class ExchangerEmailSender : IEmailSender
        {
            public void SendEmail(string clientEmail, string subject, string content)
            {
                // exchangers configuration and logic ...

                Console.WriteLine($"Sending email via Exchanger throw SMTP protocol...");
                Console.WriteLine($"To: {clientEmail}");
                Console.WriteLine($"Subject: {subject}");
                Console.WriteLine($"Content: {content}");
            }
        }
        class EmailNotification
        {
            private readonly IEmailSender _emailSender;
            public EmailNotification(IEmailSender emailSender)
            {
                _emailSender = emailSender;
            }
            public void Send(string clientEmail, string subject, string content)
                => _emailSender.SendEmail(clientEmail, subject, content);
        }

        static void Main(string[] args)
        {
            EmailNotification emailNotification;

            var clientEmail = "client@email.com";
            var subject = "Confirm your email";
            var content = "Click this link to confirm your email";

            // Gmail
            emailNotification = new EmailNotification(new GmailEmailSender());
            emailNotification.Send(clientEmail, subject, content);

            Console.WriteLine();

            // Exchanger
            emailNotification = new EmailNotification(new ExchangerEmailSender());
            emailNotification.Send(clientEmail, subject, content);

            Console.ReadKey();
        }
    }
}
