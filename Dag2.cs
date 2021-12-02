using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Dag2 : Dag
    {
        public string[] debug = new string[10];
        public Dag2(string s) : base(s)
        {

        }

        public override void Puzzel1()
        {
            int depth = 0;
            int distance = 0;
            for(int i = 0; i < 1000; i++)
            {
                int value = getValue(i);
                switch(lines[i][0])
                {
                    case 'd':
                        depth += value;
                        break;

                    case 'u':
                        depth -= value;
                        break;

                    case 'f':
                        distance += value;
                        break;
                }
                
            }
            debug[0] += depth;
            debug[1] += distance;
            this.result1 = (depth * distance).ToString();
        }

        public override void Puzzel2()
        {
            int depth = 0;
            int distance = 0;
            int aim = 0;
            for (int i = 0; i < 1000; i++)
            {
                int value = getValue(i);
                switch (lines[i][0])
                {
                    case 'd':
                        aim += value;
                        break;

                    case 'u':
                        aim -= value;
                        break;

                    case 'f':
                        distance += value;
                        depth += (aim * value);
                        break;
                }
                
            }
            debug[0] += depth;
            debug[1] += distance;
            this.result2 = (depth * distance).ToString();
        }

        public int getValue(int i)
        {
            return Int32.Parse(lines[i].Split(' ')[1]);
        }
    }
}
