using System;
using System.Collections.Generic;
using System.Text;

namespace SecureCalculator
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

        double ICalculator.Multiply(double lhs, double rhs)
        {
            return lhs * rhs;
        }

        double ICalculator.Divide(double lhs, double rhs)
        {
            return lhs / rhs;
        }
     }
}
