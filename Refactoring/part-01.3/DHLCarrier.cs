using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.part_03
{
    public class DHLCarrier : ICarrier
    {
        public string Name => "DHL";
        public decimal Calculate( decimal weightKg)
        {
            return  weightKg * 18m;
        }

    }
}
