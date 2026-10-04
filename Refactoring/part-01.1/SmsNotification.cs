using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.part_01
{
    public class SmsNotification : INotification
    {
        public void Send(string to,string message)
        {
            Console.WriteLine($"[sms] {to}: {message}");
        }
    }
}
