using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.part_03
{
    public class AramexCarrier : ICarrier
    {
        public string Name => "Aramex";
        public decimal Calculate(decimal weightKg)
        {
            return weightKg * 12m;
        }
    }
}
