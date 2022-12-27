using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Maths;

public class EvaluateClass
{
    public double Eval(double val1, double val2, string op)
    {
        if (op == "+")  return val1 + val2;
        if (op == "-")  return val1 - val2;
        if (op == "*")  return val1 * val2;
        if (op == "/")  return val1 / val2;
        if (op == "^")  return Math.Pow(val1, val2);
        return 0;
    }
}
