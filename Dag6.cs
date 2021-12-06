using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Dag6 : Dag
    {
        public Dag6(string s) : base(s)
        {
            
        }

        public List<int> starterfish = new List<int>();

        public override void Puzzel1()
        {
            string[] fishstrings = lines[0].Split(',');
            for (int i = 0; i < fishstrings.Length; i++)
                starterfish.Add(Int32.Parse(fishstrings[i]));
            this.result1 = passDays(starterfish, 80).Count.ToString();
        }

        public override void Puzzel2()
        {
            Dictionary<int, Int64> fishdict = new Dictionary<int, Int64>();
            for (int i = 0; i < 11; i++)
                fishdict.Add(i, 0);
            foreach(int elem in starterfish)
            {
                fishdict[elem]++;
            }
            Dictionary<int, Int64> finaldict = passDays2(fishdict, 256);
            Int64 total = 0;
            for (int i = 0; i < 10; i++)
                total += finaldict[i];
            this.result2 = total.ToString();
        }

        public List<int> passDays(List<int> fishIn, int days)
        {
            List<int> fishOut = new List<int>();
            foreach(int element in fishIn)
            {
                if (element > 0)
                    fishOut.Add(element - 1);
                else if( element == 0)
                {
                    fishOut.Add(8);
                    fishOut.Add(6);
                }
            }
            int nextday = days - 1;
            int donothing = 0;
            if (nextday % 10 == 0)
                donothing++;
            if (nextday < 1)
                return fishOut;
            else
                return passDays(fishOut, nextday);
        }

        public Dictionary<int, Int64> passDays2(Dictionary<int,Int64> today, int days)
        {
            Dictionary<int, Int64> nextday = today;
            nextday[9] = nextday[0];
            nextday[7] += nextday[0];
            for(int i = 0; i < 10; i++)
            {
                nextday[i] = nextday[i + 1];
            }
            if (days == 1)
                return nextday;
            else
                return passDays2(nextday, days - 1);
        }
    }
}
