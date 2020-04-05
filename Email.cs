using System;

namespace Builder.Emails
{
    public class Email
    {
        public string From, To, Subject, Body;
    }


    public class MailService
    {
        public class EmailBuilder
        {
            private readonly Email email;
            public EmailBuilder(Email email) => this.email = email;
            public EmailBuilder From(string from)
            {
                email.From = from;
                return this;
            }

            public EmailBuilder To(string to)
            {
                email.To = to;
                return this;
            }

            public EmailBuilder Subject(string subject)
            {
                email.Subject = subject;
                return this;
            }

            public EmailBuilder Body(string body)
            {
                email.Body = body;
                return this;
            }
        }
        private void SendEmailInternal(Email email)
        {
            Console.WriteLine(string.Format(
                "From:{0}" + Environment.NewLine +
                "To:{1}" + Environment.NewLine +
                "Subject:{2}" + Environment.NewLine +
                "Message:{3}" + Environment.NewLine
            , email.From, email.To, email.Subject, email.Body));
        }
        public void SendEmail(Action<EmailBuilder> builder)
        {
            var email = new Email();
            builder(new EmailBuilder(email));
            SendEmailInternal(email);

        }
    }
}