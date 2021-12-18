using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventOfCode2021
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Dag dag = new Dag1(@"C:\Users\flroelof\source\repos\AdventOfCode2021\AdventOfCode2021\Input\dag1.in");
            answer1.Text = dag.result2;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            debuglabel.Text = comboBox1.SelectedIndex.ToString();
            if(comboBox1.SelectedIndex==0)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"\input\dag1.in";
                Dag dag = new Dag1(path);
                answer1.Text = dag.result1;
                answer2.Text = dag.result2;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"\input\dag2.in";
                Dag2 dag = new Dag2(path);
                answer1.Text = dag.result1;
                answer2.Text = dag.result2;
                debuglabel.Text = dag.debug[0];
                debuglabel2.Text = dag.debug[1];
            }
            if (comboBox1.SelectedIndex == 2)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"\input\dag3.in";
                Dag3 dag = new Dag3(path);
                answer1.Text = dag.result1;
                answer2.Text = dag.result2;
                debuglabel.Text = dag.debug[0];
                debuglabel2.Text = dag.debug[1];
            }
            if(comboBox1.SelectedIndex == 3)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"\input\dag4.in";
                Dag4 dag = new Dag4(path);
                answer1.Text = dag.result1;
                answer2.Text = dag.result2;

            }
            if (comboBox1.SelectedIndex == 4)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"\input\dag5.in";
                Dag5 dag = new Dag5(path);
                answer1.Text = dag.result1;
                answer2.Text = dag.result2;
                //debuglabel.Text = dag.debug[0];
                //debuglabel2.Text = dag.debug[1];
            }
            if (comboBox1.SelectedIndex == 5)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"\input\dag6.in";
                Dag6 dag = new Dag6(path);
                answer1.Text = dag.result1;
                answer2.Text = dag.result2;
                //debuglabel.Text = dag.debug[0];
                //debuglabel2.Text = dag.debug[1];
            }
            if (comboBox1.SelectedIndex == 6)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"\input\dag8.in";
                Dag8 dag = new Dag8(path);
                answer1.Text = dag.result1;
                answer2.Text = dag.result2;
                debuglabel.Text = dag.debug[0];
                //debuglabel2.Text = dag.debug[1];
            }
            if (comboBox1.SelectedIndex == 7)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"\input\dag9.in";
                Dag9 dag = new Dag9(path, false);
                answer1.Text = dag.result1;
                answer2.Text = dag.result2;
                //debuglabel.Text = dag.debug[0];
                //debuglabel2.Text = dag.debug[1];
            }
            if (comboBox1.SelectedIndex == 8)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"\input\dag10.in";
                Dag10 dag = new Dag10(path);
                answer1.Text = dag.result1;
                answer2.Text = dag.result2;
                //debuglabel.Text = dag.debug[0];
                //debuglabel2.Text = dag.debug[1];
            }
            if (comboBox1.SelectedIndex == 9)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"\input\dag11.in";
                Dag11 dag = new Dag11(path, false);
                answer1.Text = dag.result1;
                answer2.Text = dag.result2;
                //debuglabel.Text = dag.debug[0];
                //debuglabel2.Text = dag.debug[1];
            }
            if (comboBox1.SelectedIndex == 10)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"\input\dag12.in";
                Dag12 dag = new Dag12(path);
                answer1.Text = dag.result1;
                answer2.Text = dag.result2;
                richTextBox1.Text = dag.debug[3];
                debuglabel.Text = dag.debug[0];
                debuglabel2.Text = dag.debug[1];
            }
            if (comboBox1.SelectedIndex == 11)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"\input\dag12.in";
                Dag12p dag = new Dag12p(path);
                answer1.Text = dag.result1;
                answer2.Text = dag.result2;
                richTextBox1.Text = dag.debug[3];
                debuglabel.Text = dag.debug[0];
                //debuglabel2.Text = dag.debug[1];
            }
            if (comboBox1.SelectedIndex == 12)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"\input\dag14.in";
                Dag14 dag = new Dag14(path);
                answer1.Text = dag.result1;
                answer2.Text = dag.result2;
                //richTextBox1.Text = dag.debug[3];
                //debuglabel.Text = dag.debug[0];
                //debuglabel2.Text = dag.debug[1];
            }
            if (comboBox1.SelectedIndex == 13)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"\input\dag15.in";
                Dag15 dag = new Dag15(path);
                answer1.Text = dag.result1;
                answer2.Text = dag.result2;
                richTextBox1.Text = dag.debug[3];
                //debuglabel.Text = dag.debug[0];
                //debuglabel2.Text = dag.debug[1];
            }
        }
    }
}
