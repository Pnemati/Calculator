using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rechner___Stack____Kopie
{
    public partial class Form1 : Form
    {
        string x;      // Enterd Number as string
        double xx = 0;     // Convert x to double
        double y;
        double val1;   // Operant 
        double val2;
        string op;     // Operator
        Stack<double> NumberStack;   // Save Operants
        Stack<string> OperStack;     // Save Operators
        Stack<string> AllEnterd;
        EvaluateClass EvaluateC;     // Evaluation
        ChoooseOPClass ChooseOp;
        public Form1()
        {
            InitializeComponent();
            NumberStack = new Stack<double>();
            OperStack = new Stack<string>();
            OperStack.Push("");
            AllEnterd = new Stack<string>();
            AllEnterd.Push("");
            EvaluateC = new EvaluateClass();
            ChooseOp = new ChoooseOPClass();
        }

        private void NumbersClick(object sender, EventArgs e)
        {
            Button w = (Button)sender;
            DisplayTB.Text += w.Text;
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

        private void OperatorClick(object sender, EventArgs e)
        {
            x = "";
            Button w = (Button)sender;
            op = w.Text;

            //if (OperStack.Count() != 0 && OperStack.Peek() == "Sin")
            //{
            //    double a = ((NumberStack.Pop() * (Math.PI)) / 180);
            //    y = Math.Sin(a);
            //    NumberStack.Push(y);
            //}

            if (OperStack.Count() != 0 && (OperStack.Peek() == "*" || OperStack.Peek() == "/" || OperStack.Peek() == "^"))  // Evalute Multiplication
            {
                if(op != "(")
                {
                    val2 = NumberStack.Pop();
                    val1 = NumberStack.Pop();
                    op = OperStack.Pop();
                    EvaluateC.Eval(val1, val2, op, ref y);
                    NumberStack.Push(y);
                }
            }

            op = w.Text;
            switch (op)
            {
                case "+":   { op = "+"; OperStack.Push(op); AllEnterd.Push(op); break; }
                case "-":   { op = "-"; OperStack.Push(op); AllEnterd.Push(op); break; }
                case "×":   { op = "*"; OperStack.Push(op); AllEnterd.Push(op); break; }
                case "÷":   { op = "/"; OperStack.Push(op); AllEnterd.Push(op); break; }
                case "(":   { op = "("; OperStack.Push(op); AllEnterd.Push(op); break; }
                case "x^y": { op = "^"; OperStack.Push(op); AllEnterd.Push(op); break; }
                case "Sin": { op = "Sin"; OperStack.Push(op); AllEnterd.Push(op); break; }
            }
            DisplayTB.Text += op;

            if (op == ")")                        // Evalute Parentheses
            {
                while (OperStack.Peek() != "(")
                {
                    val2 = NumberStack.Pop();
                    op  = OperStack.Pop();
                    val1 = NumberStack.Pop();
                    EvaluateC.Eval(val1, val2, op, ref y);
                    NumberStack.Push(y);
                }
                OperStack.Pop();
            }
        }

        private void EvaluateB_Click(object sender, EventArgs e)
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

        private void ReverseB_Click(object sender, EventArgs e)
        {
            xx = 1 / xx;
            DisplayTB.Text += " = " + xx;
        }

        private void SCTC_Click(object sender, EventArgs e)
        {

        }

        private void CleanClick(object sender, EventArgs e)
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
            DisplayTB.Clear();
            OperStack.Push("");
            AllEnterd.Push("");
        }
    }
}
