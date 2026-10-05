using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.part_01
{
    public class UrgentNotification : INotification
    {
        private readonly INotification _inner;
        public UrgentNotification(INotification inner)
        {
            _inner = inner;
        }
        public void Send(string to, string message)
        {
            _inner.Send(to, $"[URGENT] {message}");

        }
    }
}
