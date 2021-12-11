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
                Dag dag = new Dag1(@"C:\Users\flroelof\source\repos\AdventOfCode2021\AdventOfCode2021\Input\dag1.in");
                answer1.Text = dag.result1;
                answer2.Text = dag.result2;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                Dag2 dag = new Dag2(@"C:\Users\flroelof\source\repos\AdventOfCode2021\AdventOfCode2021\Input\dag2.in");
                answer1.Text = dag.result1;
                answer2.Text = dag.result2;
                debuglabel.Text = dag.debug[0];
                debuglabel2.Text = dag.debug[1];
            }
            if (comboBox1.SelectedIndex == 2)
            {
                Dag3 dag = new Dag3(@"C:\Users\flroelof\source\repos\AdventOfCode2021\AdventOfCode2021\Input\dag3.in");
                answer1.Text = dag.result1;
                answer2.Text = dag.result2;
                debuglabel.Text = dag.debug[0];
                debuglabel2.Text = dag.debug[1];
            }
            if(comboBox1.SelectedIndex == 3)
            {
                Dag4 dag = new Dag4(@"C:\Users\flroelof\source\repos\AdventOfCode2021\AdventOfCode2021\Input\dag4.in");
                answer1.Text = dag.result1;
                answer2.Text = dag.result2;

            }
            if (comboBox1.SelectedIndex == 4)
            {
                Dag5 dag = new Dag5(@"C:\Users\flroelof\source\repos\AdventOfCode2021\AdventOfCode2021\Input\dag5.in");
                answer1.Text = dag.result1;
                answer2.Text = dag.result2;
                //debuglabel.Text = dag.debug[0];
                //debuglabel2.Text = dag.debug[1];
            }
            if (comboBox1.SelectedIndex == 5)
            {
                Dag6 dag = new Dag6(@"C:\Users\flroelof\source\repos\AdventOfCode2021\AdventOfCode2021\Input\dag6.in");
                answer1.Text = dag.result1;
                answer2.Text = dag.result2;
                //debuglabel.Text = dag.debug[0];
                //debuglabel2.Text = dag.debug[1];
            }
            if (comboBox1.SelectedIndex == 6)
            {
                Dag8 dag = new Dag8(@"C:\Users\flroelof\source\repos\AdventOfCode2021\AdventOfCode2021\Input\dag8.in");
                answer1.Text = dag.result1;
                answer2.Text = dag.result2;
                debuglabel.Text = dag.debug[0];
                //debuglabel2.Text = dag.debug[1];
            }
            if (comboBox1.SelectedIndex == 7)
            {
                Dag9 dag = new Dag9(@"C:\Users\flroelof\source\repos\AdventOfCode2021\AdventOfCode2021\Input\dag9.in", false);
                answer1.Text = dag.result1;
                answer2.Text = dag.result2;
                //debuglabel.Text = dag.debug[0];
                //debuglabel2.Text = dag.debug[1];
            }
            if (comboBox1.SelectedIndex == 8)
            {
                Dag10 dag = new Dag10(@"C:\Users\flroelof\source\repos\AdventOfCode2021\AdventOfCode2021\Input\dag10.in");
                answer1.Text = dag.result1;
                answer2.Text = dag.result2;
                //debuglabel.Text = dag.debug[0];
                //debuglabel2.Text = dag.debug[1];
            }
            if (comboBox1.SelectedIndex == 9)
            {
                Dag11 dag = new Dag11(@"C:\Users\flroelof\source\repos\AdventOfCode2021\AdventOfCode2021\Input\dag11.in", false);
                answer1.Text = dag.result1;
                answer2.Text = dag.result2;
                //debuglabel.Text = dag.debug[0];
                //debuglabel2.Text = dag.debug[1];
            }
        }
    }
}
