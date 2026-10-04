using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.part_01
{
    public class WhatsAppNotification : INotification
    {
        public void Send(string to, string message)
        {
            Console.WriteLine($"[whatsapp] {to}: {message}");
        }
    }
}
