using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Dag1 : Dag
    {
        public Dag1(string s) : base(s)
        {

        }
        public override void Puzzel1()
        {
            int[] depths = new int[2000];
            for (int i = 0; i < 2000; i++)
                depths[i] = Int32.Parse(this.lines[i]);
            int count = 0;
            for (int i = 1; i < 2000; i++)
            {
                int current = depths[i];
                int previous = depths[i - 1];
                if (current > previous)
                    count++;
            }
            this.result1 = count.ToString();
        }
        public override void Puzzel2()
        {
            int[] depths = new int[2000];
            for (int i = 0; i < 2000; i++)
                depths[i] = Int32.Parse(this.lines[i]);
            int count = 0;
            for (int i = 2; i < 1999; i++)
            {
                int current = windowsum(depths, i);
                int previous = windowsum(depths, i - 1);
                if (current > previous)
                    count++;
            }
            this.result2 = count.ToString();
        }

        static int windowsum(int[] depths, int centre)
        {
            int answer = 0;
            answer = answer + depths[centre - 1];
            answer = answer + depths[centre];
            answer = answer + depths[centre + 1];
            return answer;
        }
    }
}
