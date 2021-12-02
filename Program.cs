using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventOfCode2021
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        }
    }

    public abstract class Dag
    {
        private string path;
        public string[] lines
        {
            get;
            set;
        }
        public string result1
        {
            get;
            set;
        }
        public string result2
        {
            get;
            set;
        }
        public Dag(string input)
        {
            this.path = input;
            string rawinput = System.IO.File.ReadAllText(path, System.Text.Encoding.UTF8);
            this.lines = rawinput.Split('\n');
            Puzzel1();
            Puzzel2();
        }

        public abstract void Puzzel1();
        public abstract void Puzzel2();
    }
}
