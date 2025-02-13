using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Calculator
{
    public partial class Form1 : Form
    {
        private double firstNumber = 0;
        private string operation = "";
        private bool newNumber = true;

        public Form1()
        {
            InitializeComponent();
            
            btn0.Click += new EventHandler(NumberButton_Click);
            btn1.Click += new EventHandler(NumberButton_Click);
            btn2.Click += new EventHandler(NumberButton_Click);
            btn3.Click += new EventHandler(NumberButton_Click);
            btn4.Click += new EventHandler(NumberButton_Click);
            btn5.Click += new EventHandler(NumberButton_Click);
            btn6.Click += new EventHandler(NumberButton_Click);
            btn7.Click += new EventHandler(NumberButton_Click);
            btn8.Click += new EventHandler(NumberButton_Click);
            btn9.Click += new EventHandler(NumberButton_Click);

            btnAdd.Click += new EventHandler(OperationButton_Click);
            btnSubtract.Click += new EventHandler(OperationButton_Click);
            btnMultiply.Click += new EventHandler(OperationButton_Click);
            btnDivide.Click += new EventHandler(OperationButton_Click);
            btnEquals.Click += new EventHandler(btnEquals_Click);
            btnClear.Click += new EventHandler(btnClear_Click);
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (newNumber)
            {
                txtDisplay.Text = button.Text;
                newNumber = false;
            }
            else
            {
                txtDisplay.Text += button.Text;
            }
        }


        private void OperationButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            firstNumber = Convert.ToDouble(txtDisplay.Text);
            operation = button.Text;
            newNumber = true;
        }


        private void btnEquals_Click(object sender, EventArgs e)
        {
            double secondNumber = Convert.ToDouble(txtDisplay.Text);
            double result = 0;

            switch (operation)
            {
                case "+":
                result = firstNumber + secondNumber;
                break;


                case "-":
                result = firstNumber - secondNumber;
                break;


                case "×":
                result = firstNumber * secondNumber;
                break;


                case "÷":
                if (secondNumber != 0)
                {
                  result = firstNumber / secondNumber;
                }
                else
                {
                  MessageBox.Show("Invalid");
                  return;
                }
                break;
            }

            txtDisplay.Text = result.ToString();
            firstNumber = result;
            operation = "";
            newNumber = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            firstNumber = 0;
            operation = "";
            newNumber = true;
        }
    }
}
