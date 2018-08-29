using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Calc;
using Analaizer;
using System.Diagnostics;

namespace CalcForm
{
    public partial class Form1 : Form
    {
        public string expr
        {
            set {
                textBox1.Text = value;
                AnalaizerClass.expression = value;
                button1_Click(null, null);
            }
        }

        public Form1(string expr)
        {
            InitializeComponent();
            memory = 0;
            mOrp = 'p';
            AnalaizerClass.expression = expr;
            button1_Click(null, null);

            this.Show();
        }

        private static int memory;
        private static Stopwatch timer = new Stopwatch();
        private static char mOrp;
        public Form1()
        {
            memory = 0;
            mOrp = 'p';
            InitializeComponent();
           // textBox1.Text = expr;
           // AnalaizerClass.expression = expr;
          //  button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            timer.Stop();
            AnalaizerClass.expression = textBox1.Text;
            label3.Text = AnalaizerClass.Estimate();
            label3.ForeColor = Color.Black;
            if (!AnalaizerClass.ShowMessage)
            {
                textBox1.BackColor = Color.Red;
                label3.ForeColor = Color.Red;
            }
            AnalaizerClass.ShowMessage = true;
            AnalaizerClass.expression = "";
            AnalaizerClass.erposition = -1;
         /*
            Class2 alalizerOb = new Class2(tbExpression.Text);
            tbRes.Text = Class2.Estimate();
            tbExpression.Text = "0";
        */
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            timer.Stop();
            textBox1.BackColor = Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer.Stop();
            textBox1.Text += ((Button)sender).Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer.Stop();
            //textBox1.Text += "2";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer.Stop();
            textBox1.Text += "3";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            timer.Stop();
            textBox1.Text += "4";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            timer.Stop();
            textBox1.Text += "5";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            timer.Stop();
            textBox1.Text += "6";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            timer.Stop();
            textBox1.Text += "7";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            timer.Stop();
            textBox1.Text += "8";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            timer.Stop();
            textBox1.Text += "9";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            timer.Stop();
            textBox1.Text += "0";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            timer.Stop();
            textBox1.Text += "/";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            timer.Stop();
            textBox1.Text += "*";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            timer.Stop();
            textBox1.Text += "-";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            timer.Stop();
            textBox1.Text += "+";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            timer.Stop();
            textBox1.Text += "%";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Stop();
            textBox1.Text += "(";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer.Stop();
            textBox1.Text += ")";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            timer.Stop();
            if (textBox1.Text.Length != 0)
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            timer.Stop();
            textBox1.Text = "";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            timer.Stop();
            memory = 0;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            timer.Stop();
            if (memory != 0)
               textBox1.Text += memory.ToString();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            timer.Stop();
            AnalaizerClass.expression = textBox1.Text;
            string temp = AnalaizerClass.Estimate();
            if (!AnalaizerClass.ShowMessage)
            {
                label3.Text = temp;
                textBox1.BackColor = Color.Red;
                label3.ForeColor = Color.Red;
            }
            else
            {
                textBox1.Text = "";
                memory = Int32.Parse(temp);
                label3.Text = memory.ToString() + " successfully added to memory";
                label3.ForeColor = Color.Green;
            }

            AnalaizerClass.ShowMessage = true;
            AnalaizerClass.expression = "";
            AnalaizerClass.erposition = -1;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (timer.IsRunning)
            {
                timer.Stop();
                if(timer.Elapsed.Seconds < 3)     
                {
                    if (textBox1.Text.Length <= 0 || textBox1.Text.Last() == 'p')
                    {
                        if (textBox1.Text.Length > 0)
                        {
                            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                        }

                        textBox1.Text += 'm';
                    }
                    else if (textBox1.Text.Last() == 'm')
                        textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1) + 'p';
                    else
                        textBox1.Text += 'm';
                }
                else
                {
                    if (textBox1.Text.Length > 0 && textBox1.Text.Last() == 'm' || textBox1.Text.Last() == 'p')
                    {
                        textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                    }

                    if(textBox1.Text.Length > 0)
                        textBox1.Text = "m(" + textBox1.Text + ")";

                }

                timer = Stopwatch.StartNew();
            }
            else
            {
                textBox1.Text += 'm';
                timer = Stopwatch.StartNew();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {
            timer.Stop();
            textBox1.Text += ",";
        }
    }
}
