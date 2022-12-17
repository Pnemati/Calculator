using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationCalc
{
    public partial class WebForm1 : System.Web.UI.Page
    {
            string x;      // Enterd Number as string
            double xx = 0;     // Convert x to double
            double y;
            double val1;   // Operant 
            double val2;
            string op;     // Operator
            Stack<double> NumberStack = new Stack<double>();   // Save Operants
            Stack<string> OperStack = new Stack<string>();     // Save Operators
            Stack<string> AllEnterd = new Stack<string>();
            EvaluateClass EvaluateC = new EvaluateClass();     // Evaluation


        public WebForm1()
        {
            OperStack.Push("");           
            AllEnterd.Push("");            
        }
        protected void Number_Click(object sender, EventArgs e)
        {
            Button w = (Button)sender;
            DisplayTB.Text += w.Text.ToString();
            x += w.Text;
            xx = Convert.ToDouble(x);

            if (AllEnterd.Peek() != OperStack.Peek())
            {
                if (NumberStack.Count() != 0) NumberStack.Pop();
                NumberStack.Push(xx);
            }
            else NumberStack.Push(xx);

            AllEnterd.Push(x);
        }

        protected void Operator_Click(object sender, EventArgs e)
        {
            x = "";
            Button w = (Button)sender;
            op = w.Text.ToString();

            //if (OperStack.Count() != 0 && OperStack.Peek() == "Sin")
            //{
            //    double a = ((NumberStack.Pop() * (Math.PI)) / 180);
            //    y = Math.Sin(a);
            //    NumberStack.Push(y);
            //}

            if (OperStack.Count() != 0 && (OperStack.Peek() == "*" || OperStack.Peek() == "/" || OperStack.Peek() == "^"))  // Evalute Multiplication
            {
                if (op != "(")
                {
                    val2 = NumberStack.Pop();
                    val1 = NumberStack.Pop();
                    op = OperStack.Pop();
                    EvaluateC.Eval(val1, val2, op, ref y);
                    NumberStack.Push(y);
                }
            }

            op = w.Text.ToString();
            switch (op)
            {
                case "+": { op = "+"; OperStack.Push(op); AllEnterd.Push(op); break; }
                case "-": { op = "-"; OperStack.Push(op); AllEnterd.Push(op); break; }
                case "×": { op = "*"; OperStack.Push(op); AllEnterd.Push(op); break; }
                case "÷": { op = "/"; OperStack.Push(op); AllEnterd.Push(op); break; }
                case "(": { op = "("; OperStack.Push(op); AllEnterd.Push(op); break; }
                case "x^y": { op = "^"; OperStack.Push(op); AllEnterd.Push(op); break; }
                case "Sin": { op = "Sin"; OperStack.Push(op); AllEnterd.Push(op); break; }
            }
            DisplayTB.Text += op;

            if (op == ")")                        // Evalute Parentheses
            {
                while (OperStack.Peek() != "(")
                {
                    val2 = NumberStack.Pop();
                    op = OperStack.Pop();
                    val1 = NumberStack.Pop();
                    EvaluateC.Eval(val1, val2, op, ref y);
                    NumberStack.Push(y);
                }
                OperStack.Pop();
            }
        }

        protected void Evaluate_Click(object sender, EventArgs e)
        {
            DisplayTB.Text += " = ";              // Evalute Plus and Minus
            while (OperStack.Peek() != "")
            {
                op = OperStack.Pop();
                val2 = NumberStack.Pop();
                val1 = NumberStack.Pop();
                EvaluateC.Eval(val1, val2, op, ref y);
                NumberStack.Push(y);
            }
            DisplayTB.Text += y;
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            op = null;
            x = null;
            xx = 0;
            y = 0;
            val1 = 0;
            val2 = 0;
            NumberStack.Clear();
            OperStack.Clear();
            AllEnterd.Clear();
            DisplayTB = null;
            OperStack.Push("");
            AllEnterd.Push("");
        }
    }
}