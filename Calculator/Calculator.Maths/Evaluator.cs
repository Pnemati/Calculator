using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Calculator.Maths
{
    public class Evaluator
    {
        private Stack<double> NumberStack = new();   // Save Operants
        private Stack<string> OperStack = new();     // Save Operators
        Stack<string> AllEnterd = new();
        EvaluateClass EvaluateC = new EvaluateClass();  // Evaluation
 
        private Evaluator()
        {
            OperStack.Push("");
            AllEnterd.Push("");

        }

        private double Evaluate(string expression)
        {
            PutExpressionIntoStacks(expression);
            return EvaluateStacks();
        }

        // Präzedenz
        // + = 1
        // - = 1
        // * = 2
        // / = 2
        // ^ = 3
        // Dictionary

        // o o o o o      X
        // 1 1 2 1 2      1
        //        ^

        private void PutExpressionIntoStacks(string expression)
        {
            string x = "";      // Enterd Number as string
            double xx = 0;     // Convert x to double
            double val1;      // Operant 
            double val2;
            string op;     // Operator
            // StateMachine of the calculation
            bool lastWasNumber = false;
            bool isAfterDecimalPoint = false;
            int decimalPlaces = 0;

            foreach (var c in expression)
            {
                if (char.IsNumber(c))
                {
                    int num = (c - '0');
                    x += c;
                    xx = Convert.ToDouble(x);

                    if (lastWasNumber) 
                    {
                        if (isAfterDecimalPoint) 
                        {
                            xx = 10 * xx + num;
                        }
                        else
                        {
                            xx = xx + num * Math.Pow(10, -decimalPlaces);
                            decimalPlaces++;
                        }
                    }
                    else
                    {
                        xx = num;
                    }

                    AllEnterd.Push(Convert.ToString(xx));
                    lastWasNumber = true;
                }
                else // keine Ziffer
                {
                    if (lastWasNumber) 
                    {
                        NumberStack.Push(xx); // Not yet
                        xx = 0;
                    }

                    if (c == '+')
                    {
                        OperStack.Push("+");
                    }
                    else if (c == '-')
                    {
                        OperStack.Push("-");
                    }
                    else if (c == '*')
                    {
                        OperStack.Push("*");
                    }
                    else if (c == '/')
                    {
                        OperStack.Push("/");
                    }


                    //if (OperStack.Count() != 0 && (OperStack.Peek() == "*" || OperStack.Peek() == "/" || OperStack.Peek() == "^"))  // Evalute Multiplication
                    //{
                    //    if (op != "(")
                    //    {
                    //        val2 = NumberStack.Pop();
                    //        val1 = NumberStack.Pop();
                    //        op = OperStack.Pop();
                    //        var evalResult = EvaluateC.Eval(val1, val2, op);
                    //        NumberStack.Push(evalResult);
                    //    }
                    //}

                    ///*op = w.Text;/´*/
                    //switch (op)
                    //{
                    //    case "+": { op = "+"; OperStack.Push(op); AllEnterd.Push(op); break; }
                    //    case "-": { op = "-"; OperStack.Push(op); AllEnterd.Push(op); break; }
                    //    case "×": { op = "*"; OperStack.Push(op); AllEnterd.Push(op); break; }
                    //    case "÷": { op = "/"; OperStack.Push(op); AllEnterd.Push(op); break; }
                    //    case "(": { op = "("; OperStack.Push(op); AllEnterd.Push(op); break; }
                    //    case "x^y": { op = "^"; OperStack.Push(op); AllEnterd.Push(op); break; }
                    //}

                    //if (op == ")")                        // Evalute Parentheses
                    //{
                    //    while (OperStack.Peek() != "(")
                    //    {
                    //        val2 = NumberStack.Pop();
                    //        op = OperStack.Pop();
                    //        val1 = NumberStack.Pop();
                    //        var evalResult = EvaluateC.Eval(val1, val2, op);
                    //        NumberStack.Push(evalResult);
                    //    }

                    //    OperStack.Pop();
                    //}



                    // TODO hier die Operatoren und den dezimalpunkt





                    lastWasNumber = false;
                }
            }

            // wenn als letztes noch eine nummer steht, muss die auf den stack.
            if (lastWasNumber)
            {
                NumberStack.Push(xx);
            }
        }

        private double EvaluateStacks()
        {
            double val1;   // Operant 
            double val2;
            string op;     // Operator


            while (OperStack.Peek() != "")
            {
                op = OperStack.Pop();
                val2 = NumberStack.Pop();
                val1 = NumberStack.Pop();
                var evalResult = EvaluateC.Eval(val1, val2, op);
                NumberStack.Push(evalResult);
            }

            return NumberStack.Pop();
        }

        /// <summary>
        /// Convenient starter method for the evaluation
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static double EvaluateExpression(string expression)
        {
            var evaluator = new Evaluator();
            return evaluator.Evaluate(expression);
        }

    }
}
