using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.part_01
{
    public class UrgentScheduledNotification : INotification
    {
        private readonly INotification _inner;
        public DateTime SendAt { get; }
        public UrgentScheduledNotification(INotification inner, DateTime sendAt)
        {
            _inner = inner;
            SendAt = sendAt;
        }
        public void Send(string to, string message)
        {
            _inner.Send(to, $"[scheduled {SendAt:g}] {message}");
        }
    }
}
