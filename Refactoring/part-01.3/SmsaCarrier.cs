using Refactoring.part_03;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.part_01._3
{
    public class SmsaCarrier : ICarrier
    {
        public string Name => "Smsa";
        public decimal Calculate(decimal weightKg)
        {
            return weightKg * 10m;
        }
    }
}
