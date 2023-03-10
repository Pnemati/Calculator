using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationCalc
{
    public class EvaluateClass
    {
        public double Eval(double val1, double val2, string op, ref double y)
        {
            if (op == "+") return y = val1 + val2;
            if (op == "-") return y = val1 - val2;
            if (op == "*") return y = val1 * val2;
            if (op == "/") return y = val1 / val2;
            if (op == "^") return y = System.Math.Pow(val1, val2);
            return 0;
        }
    }
}