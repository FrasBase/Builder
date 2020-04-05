using System;
using Builder.Persons;
using Builder.Emails;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var pb = new PersonBuilder();
            Person person = pb.Lives.At("Krzycka").In("Wrocław").WithPostcode("53-019").Works.AsA("Developer").At("Microsoft").Earning(100000);

            Console.WriteLine(person);

            var ms = new MailService();

            ms.SendEmail(email => email.From("kamil@wro.pl").To("micro@soft.pl").Subject("Hello topic").Body("Hi Micro"));

        }
    }
}
