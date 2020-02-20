using System;
using System.Collections.Generic;
using System.Text;

namespace Secure_Calculator_Technical_Challenge.Calculator
{
    public class BasicCalculator : ICalculator
    {
        double ICalculator.Add(double lhs, double rhs)
        {
            return lhs + rhs;
        }

        double ICalculator.Subtract(double lhs, double rhs)
        {
            return lhs - rhs;
        }
     }
}
