using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Dag9 : Dag
    {
        public string[] debug = new string[10];
        public int rowcount = 0;
        public int columncount = 0;
        int[,] cavemap;
        List<int[]> lowpoints = new List<int[]>();

        public Dag9(string s, bool f) : base(s,f)
        {
            rowcount = lines.Length;
            columncount = lines[0].Length - 1;
            cavemap = new int[rowcount, columncount];
            for (int x = 0; x < rowcount; x++)
                for (int y = 0; y < columncount; y++)
                {
                    int temp = (int)Char.GetNumericValue(lines[x], y);
                    cavemap[x, y] = temp;
                }
            Puzzel1();
            Puzzel2();
        }
        
        public override void Puzzel1()
        {
            int answer = 0;
            for (int x = 0; x < rowcount; x++)
                for (int y = 0; y < columncount; y++)
                {
                    int nodedepth = LowerThanNeighbours(x, y);
                    if (nodedepth < 10)
                        answer += (nodedepth + 1);
                }
            this.result1 = answer.ToString();
        }

        public override void Puzzel2()
        {
            List<int> bassinsizes = new List<int>();
            List<int[]> alreadychecked = new List<int[]>();
            foreach (int[] elem in lowpoints)
            {
                List<int[]> bassin = new List<int[]>();
                List<int[]> notbassin = new List<int[]>();
                List<int[]> tocheck = new List<int[]>();
                bassin.Add(elem);
                alreadychecked.Add(elem);
                addNeighbours(elem, tocheck, alreadychecked);
                while(tocheck.Count > 0 && alreadychecked.Count < this.rowcount * this.columncount)
                {
                    List<int[]> nextcheck = new List<int[]>();
                    foreach (int[] checking in tocheck)
                    {
                        //bool notinbassin = !florisContains(notbassin, checking);// !notbassin.Contains(checking);
                        bool ischecked = florisContains(alreadychecked, checking);//alreadychecked.Contains(checking);
                        if (!ischecked)
                        {
                            if (cavemap[checking[0], checking[1]] < 9)
                            {
                                bassin.Add(checking);
                                addNeighbours(checking, nextcheck, alreadychecked);
                                alreadychecked.Add(checking);
                            }
                            else
                            {
                                notbassin.Add(checking);
                                alreadychecked.Add(checking);
                            }
                                
                            
                        }
                    }
                    tocheck.Clear();
                    tocheck = nextcheck;
                    alreadychecked = alreadychecked.Distinct().ToList();
                }
                bassinsizes.Add(bassin.Count);
                
            }
            bassinsizes.Sort();
            int lastelem = bassinsizes.Count - 1;
            int answer = bassinsizes[lastelem] * bassinsizes[lastelem - 1] * bassinsizes[lastelem - 2];
            this.result2 = answer.ToString();

        }

        public int LowerThanNeighbours(int x, int y)
        {
            int currentvalue = cavemap[x, y];
            bool checkup = y == 0 || cavemap[x, y - 1] > currentvalue;
            bool checkdown = y == columncount -1 || cavemap[x, y + 1] > currentvalue;
            bool checkleft = x == 0 || cavemap[x - 1, y] > currentvalue;
            bool checkright = x == rowcount -1 || cavemap[x + 1, y] > currentvalue;
            if (checkup && checkdown && checkleft && checkright)
            {
                lowpoints.Add(new int[] { x, y });
                return currentvalue;
            }
                
            return 10;
        }

        public void addNeighbours(int[] pos, List<int[]> tocheck, List<int[]> alreadychecked)
        {
            List<int[]> newpos = new List<int[]>();
            if (pos[0] != 0)
                newpos.Add(new int[] { pos[0] - 1, pos[1] });
            if (pos[0] < this.rowcount - 1)
                newpos.Add(new int[] { pos[0] + 1, pos[1] });
            if (pos[1] != 0)
                newpos.Add(new int[] { pos[0], pos[1] - 1 });
            if (pos[1] < this.columncount - 1)
                newpos.Add(new int[] { pos[0], pos[1] + 1 });
            foreach(int[] elem in newpos)
            {
                if (!florisContains(alreadychecked, elem))//!alreadychecked.Contains(elem))
                    tocheck.Add(elem);
            }
        }

        public bool florisContains(List<int[]> inp, int[] checkvalue)
        {
            foreach(int[] elem in inp)
            {
                if (elem[0] == checkvalue[0] && elem[1] == checkvalue[1])
                    return true;
            }
            return false;
        }
    }
}
