using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.part_03
{
    public class FedExCarrier : ICarrier
    {
        public string Name => "FedEx";
        public decimal Calculate(decimal weightKg)
        {
            return weightKg * 15m;
        }
    }




}



