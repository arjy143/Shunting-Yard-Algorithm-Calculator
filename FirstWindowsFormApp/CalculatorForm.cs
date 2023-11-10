using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace FirstWindowsFormApp
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
        }
        private void CalculatorForm_Load(object sender, EventArgs e)
        {

        }
        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "1";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "2";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "3";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "4";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "5";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "6";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "7";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "8";
        }
        private void button9_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "9";
        }
        private void button0_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "0";
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += " * ";
        }
        private void buttonDiv_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += " / ";
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += " + ";
        }
        private void buttonSub_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += " - ";
        }
        private void buttonPow_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += " ^ ";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            inputTextBox.Text = string.Empty;
        }
        private void buttonOpenBracket_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += " ( ";
        }
        private void buttonCloseBracket_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += " ) ";
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            
            postfixTextBox.Text = string.Empty;
            outputTextBox.Text = string.Empty;
            var shuntAlg = new ShuntingAlgorithm();
            string[] postfix = shuntAlg.Parse(inputTextBox.Text);
            string result = shuntAlg.Evaluate(postfix);
            
            postfixTextBox.Text = string.Join(" ", postfix); ;
            outputTextBox.Text = result;
        }

        private void outputTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
