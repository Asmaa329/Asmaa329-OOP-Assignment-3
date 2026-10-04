using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.part_01._2
{
    public class OrderProcessor
    {
        private readonly IOrderRepository _repository;
        private readonly IMessageSender _messageSender;

  
        public OrderProcessor(IOrderRepository repository, IMessageSender messageSender)
        {
            _repository = repository;
            _messageSender = messageSender;
        }

        public void Process(int orderId, string customermessag)
        {
            var now = DateTime.Now;
            _repository.Save(orderId, now);
            _messageSender.Send(customermessag, $"Order {orderId} confirmed at {now:dd/MM/yyyy HH:mm:ss}");
        }
    }
}
