using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Dag10 : Dag
    {
        public Dag10(string s) : base(s)
        {

        }
        int[] charscore = new int[] { 0, 0, 0, 0, 3, 57, 1197, 25137 };
        List<int[]> linefixers = new List<int[]>();
        public string[] debug = new string[10];

        public override void Puzzel1()
        {
            int score = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                int[] linecheck = lineScore(lines[i]);
                score += linecheck[8];
                //if(linecheck[8] == 0)
                  //  incompletelines.Add(linecheck);
            }
            this.result1 = score.ToString();
        }

        public override void Puzzel2()
        {
            List<long> scores = new List<long>();
            foreach(int[] elem in linefixers)
            {
                long score = 0;
                for(int i = 0; i < elem.Length; i++)
                {
                    score *= 5;
                    score += (elem[i] - 3);
                }
                scores.Add(score);
            }
            scores.Sort();
            long middlescore = scores[scores.Count / 2];
            this.result2 = middlescore.ToString();
        }

        public int[] lineScore(string inp)
        {
            int length = inp.Length - 1;
            int[] brackets = new int[9]; // 0(,1[,2{,3<,4),5],6},7>,8score
            List<int> stillopen = new List<int>();
            for (int i = 0; i < length; i++)
            {
                int newchar = -1;
                switch (inp[i])
                {
                    case '(':
                        newchar = 0;
                        brackets[newchar]++;                        
                        break;
                    case '[':
                        newchar = 1;
                        brackets[newchar]++;
                        break;
                    case '{':
                        newchar = 2;
                        brackets[newchar]++;
                        break;
                    case '<':
                        newchar = 3;
                        brackets[newchar]++;
                        break;
                    case ')':
                        newchar = 4;
                        brackets[newchar]++;
                        break;
                    case ']':
                        newchar = 5;
                        brackets[newchar]++;
                        break;
                    case '}':
                        newchar = 6;
                        brackets[newchar]++;
                        break;
                    case '>':
                        newchar = 7;
                        brackets[newchar]++;
                        break;
                }
                if (newchar < 4)
                    stillopen.Add(newchar);
                else
                {
                    int lastpos = stillopen.Count - 1;
                    if (stillopen[lastpos] == newchar - 4)
                        stillopen.RemoveAt(lastpos);
                    else
                    {
                        brackets[8] = charscore[newchar];
                        return brackets;
                    }
                }
            }
            int[] fixerstring = new int[stillopen.Count];
            for (int i = 0; i < fixerstring.Length; i++)
            {
                int nextposition = stillopen.Count - i - 1;
                fixerstring[i] = stillopen[nextposition] + 4;
            }
            linefixers.Add(fixerstring);
            
            return brackets;
        }
    }
}
