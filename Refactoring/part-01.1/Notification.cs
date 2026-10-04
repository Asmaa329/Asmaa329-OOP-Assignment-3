using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.part_01
{
    public interface INotification
    {
        void Send(string to,string message);
    }
}
