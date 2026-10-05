using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.part_03
{
   public interface ICarrier
    {
        string Name { get; }
        decimal Calculate( decimal weightKg);
    }
}
