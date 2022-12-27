using Calculator.Maths;
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
        double xx = 0;     // Convert x to double
        public Form1()
        {
            InitializeComponent();
        }

        private void NumbersClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DisplayTB.Text += btn.Text;
            //xx = xx * 10 + (Convert.ToChar(btn.Text) - '0'); // X DisplayTB.Text[0] X
        }

        private void OperatorClick(object sender, EventArgs e)
        {
            string x = "";
            xx = 0;
            Button btn = (Button)sender;
            string op = btn.Text;

            
            // TODO hier die Operatoren und den dezimalpunkt

        }

        private void EvaluateB_Click(object sender, EventArgs e)
        {
            double result = Evaluator.EvaluateExpression(DisplayTB.Text);
            DisplayTB.Text += " = ";              // Evalute Plus and Minus
            DisplayTB.Text += result;
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
            xx = 0;
            DisplayTB.Clear();
        }
    }
}
