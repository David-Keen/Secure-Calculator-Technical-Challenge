using System;
using System.Collections.Generic;
using System.Text;

namespace Secure_Calculator_Technical_Challenge.Calculator
{
    public interface ICalculator
    {
        public double Add(double lhs, double rhs);
        public double Subtract(double lhs, double rhs);
        public double Multiply(double lhs, double rhs);
        public double Divide(double lhs, double rhs);
    }
}
