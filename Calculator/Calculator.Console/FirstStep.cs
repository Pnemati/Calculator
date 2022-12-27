using Calculator.Maths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public  class FirstStep
    {
        string x;      // Enterd Number as string
        double xx = 0;     // Convert x to double
        string X = null;
        string XX = String.Empty;
        int i;
        double y;
        double val1;   // Operant 
        double val2;
        string op;     // Operator
        string opp;     // Operator
        Stack<double> NumberStack = new Stack<double>();   // Save Operants
        Stack<string> OperStack = new Stack<string>();     // Save Operators
        Stack<string> AllEnterd = new Stack<string>();
        EvaluateClass EvaluateC = new EvaluateClass();     // Evaluation

        public FirstStep()
        {
            OperStack.Push("");
            AllEnterd.Push("");
        }

        public void EnterOp()
        {
            Console.WriteLine("Enter the mathematical question");
            X = Console.ReadLine();

            for (i = 0; i < X.Length; i++)
            {
                if (Char.IsDigit(X[i]) || X[i] == ',')
                {
                    XX += X[i];
                    AllEnterd.Push(XX);
                }
                else
                {
                    
                    if(i>0 && Char.IsDigit(X[i-1]))
                    NumberStack.Push(Convert.ToDouble(XX));
             
                    XX = null;

                    op = Convert.ToString(X[i]);

                    if (OperStack.Count() != 0 && (OperStack.Peek() == "*" || OperStack.Peek() == "/" || OperStack.Peek() == "^"))  // Evalute Multiplication
                    {
                        if (op != "(")
                        {
                            val2 = NumberStack.Pop();
                            val1 = NumberStack.Pop();
                            op = OperStack.Pop();
                            y = EvaluateC.Eval(val1, val2, op);
                            NumberStack.Push(y);
                        }
                    }
                    //OperStack.Push(opp);

                    if (X[i] == '+' || X[i] == '-' || X[i] == '/' || X[i] == '*' || X[i] == '^' || X[i] == '(' || X[i] == '=')
                    {
                        AllEnterd.Push(Convert.ToString(X[i]));
                        OperStack.Push(Convert.ToString(X[i]));
                    }
                }
            }

                opp = OperStack.Pop();
              
                if (OperStack.Peek() == ")")                        // Evalute Parentheses
                {
                    while (OperStack.Peek() != "(")
                    {
                        val2 = NumberStack.Pop();
                        op = OperStack.Pop();
                        val1 = NumberStack.Pop();
                        y = EvaluateC.Eval(val1, val2, op);
                        NumberStack.Push(y);
                    }
                }
               OperStack.Pop();
                
                while (OperStack.Peek() != "")
                {
                    op = OperStack.Pop();
                    val2 = NumberStack.Pop();
                    val1 = NumberStack.Pop();
                    y = EvaluateC.Eval(val1, val2, op);
                    NumberStack.Push(y);
                }

                Console.WriteLine(y.ToString());
        }
    }
}
