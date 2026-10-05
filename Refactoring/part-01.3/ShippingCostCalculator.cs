using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.part_03
{
    public class ShippingCostCalculator
    {
        public decimal Calculate(ICarrier carrier, decimal weightKg)
        {
            ArgumentNullException.ThrowIfNull(carrier);
            return carrier.Calculate(weightKg);
        }
    }
}
