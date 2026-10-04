using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.part_01._2
{
    public class SmtpEmailSender : IMessageSender
    {
        public void Send(string to, string body)
        {
            Console.WriteLine($"[SMTP] to={to} body={body}");
        }
    }
}
