using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calc_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string x;      // Enterd Number as string
        double xx = 0;     // Convert x to double
        double y;
        double val1;   // Operant 
        double val2;
        Stack<double> NumberStack;   // Save Operants
        Stack<string> OperStack;     // Save Operators
        Stack<string> AllEnterd;
        EvaluateClass EvaluateC;     // Evaluation
    /// <summary>
    ///    ChoooseOPClass ChooseOp;
    /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            NumberStack = new Stack<double>();
            OperStack = new Stack<string>();
            OperStack.Push("");
            AllEnterd = new Stack<string>();
            AllEnterd.Push("");
            EvaluateC = new EvaluateClass();
    ///       ChooseOp = new ChoooseOPClass();
        }


        private void NmbrB_Click(object sender, RoutedEventArgs e)
        {
            Button w = (Button)sender;
            DisplayTB.Text += w.Content.ToString();
            x += w.Content;
            xx = Convert.ToDouble(x);

            if (AllEnterd.Peek() != OperStack.Peek())
            {
                if (NumberStack.Count() != 0) NumberStack.Pop();
                NumberStack.Push(xx);
            }
            else NumberStack.Push(xx);

            AllEnterd.Push(x);
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            x = "";
            Button w = (Button)sender;
            var op = w.Content.ToString();

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

            op = w.Content.ToString();
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

        private void Evaluate_Click(object sender, RoutedEventArgs e)
        {
            DisplayTB.Text += " = ";              // Evalute Plus and Minus
            while (OperStack.Peek() != "")
            {
                var op = OperStack.Pop();
                val2 = NumberStack.Pop();
                val1 = NumberStack.Pop();
                EvaluateC.Eval(val1, val2, op, ref y);
                NumberStack.Push(y);
            }
            DisplayTB.Text += y;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
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

        private void Reverse_Click(object sender, RoutedEventArgs e)
        {
            xx = 1 / xx;
            DisplayTB.Text += " = " + xx;
        }
    }
}
