using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Dag25 : Dag
    {
        public Dag25(string s) : base(s)
        {

        }
        public char[,] currentmap;
        public char[,] nextmap;

        public override void Puzzel1()
        {
            currentmap = new char[lines[0].Length, lines.Length];
            nextmap = new char[lines[0].Length, lines.Length];
            for (int y = 0; y < lines.Length; y++)
                for(int x = 0; x < lines[0].Length; x++)
                {
                    currentmap[x,y] = lines[y][x];
                }
            filldots();
            int stepstaken = 1;
            int turncount = 0;
            while(stepstaken > 0)
            {
                stepstaken = 0;
                stepstaken += moveright();
                stepstaken += movedown();
                turncount++;
            }
            this.result1 = turncount.ToString();
        }

        public void filldots()
        {
            for (int y = 0; y < lines.Length; y++)
                for (int x = 0; x < lines[0].Length; x++)
                    nextmap[x, y] = '.';
        }

        public int moveright()
        {
            int moves = 0;
            for (int y = 0; y < lines.Length; y++)
                for (int x = 0; x < lines[0].Length; x++)
                {
                    
                    if(currentmap[x,y] == '>')
                    {
                        int nextx = x + 1;
                        if (nextx == lines[y].Length)
                            nextx = 0;
                        if (currentmap[nextx, y] == '.')
                        {
                            moves++;
                            nextmap[nextx, y] = '>';
                        }
                        else
                            nextmap[x,y] = '>';
                    }
                    else if(nextmap[x, y] == '.')
                        nextmap[x,y] = currentmap[x,y];
                }
            currentmap = nextmap;
            nextmap = new char[lines[0].Length, lines.Length];
            filldots();
            return moves;
        }

        public int movedown()
        {
            int moves = 0;
            for (int y = 0; y < lines.Length; y++)
                for (int x = 0; x < lines[0].Length; x++)
                {

                    if (currentmap[x, y] == 'v')
                    {
                        int nexty = y + 1;
                        if (nexty == lines.Length)
                            nexty = 0;
                        if (currentmap[x, nexty] == '.')
                        {
                            moves++;
                            nextmap[x, nexty] = 'v';
                        }
                        else
                            nextmap[x, y] = 'v';
                    }
                    else if (nextmap[x, y] == '.')
                        nextmap[x, y] = currentmap[x, y];
                }
            currentmap = nextmap;
            nextmap = new char[lines[0].Length, lines.Length];
            filldots();
            return moves;
        }

        public override void Puzzel2()
        {
            //throw new NotImplementedException();
        }
    }
}
