using System;
using System.Collections.Generic;
using System.Text;

namespace SecureCalculator
{
    public interface ICalculator
    {
        double Add(double lhs, double rhs);
        double Subtract(double lhs, double rhs);
        double Multiply(double lhs, double rhs);
        double Divide(double lhs, double rhs);
    }
}
