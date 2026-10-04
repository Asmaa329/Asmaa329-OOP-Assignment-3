using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.part_01._2
{
    public interface IMessageSender
    {
        void Send(string to, string body);
    }
}
