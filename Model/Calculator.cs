using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Model
{
    internal class Calculator
    {
        public double Add(double x, double y)
        {
            return x + y;
        }
        public double Subtract(double x, double y)
        {
            return x - y;
        }
        public double Multiply(double x, double y) 
        {
            return x * y; 
        }
        public double Divide(double x, double y)
        {
            return x / y;
        }
        public double Calculate(double x, double y, string operation)
        {
            switch(operation)
            {
                case "+":
                    return Add(x, y);
                case "-":
                    return Subtract(x, y);
                case "*":
                    return Multiply(x, y);
                case "/":
                    return Divide(x, y);
                default:
                    throw new Exception();
            }
        }

    }
}
