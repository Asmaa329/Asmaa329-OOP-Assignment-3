using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.part_01._2
{
    public class SqlOrderRepository : IOrderRepository
    {
 
        public void Save(int orderId, DateTime processedAt)
        {
            Console.WriteLine($"[SQL] save order {orderId} @ {processedAt:O}");
        }
    }
}
