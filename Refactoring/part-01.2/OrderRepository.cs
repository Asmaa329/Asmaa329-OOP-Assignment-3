using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.part_01._2
{
    public interface IOrderRepository
    {
        void Save(int orderId, DateTime processedAt);
    }
}
