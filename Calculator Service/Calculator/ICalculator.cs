using System;
using System.Collections.Generic;
using System.Text;

namespace Secure_Calculator_Technical_Challenge.Calculator
{
    public interface ICalculator
    {
        double Add(double lhs, double rhs);
        double Subtract(double lhs, double rhs);
        double Multiply(double lhs, double rhs);
        double Divide(double lhs, double rhs);
    }
}
