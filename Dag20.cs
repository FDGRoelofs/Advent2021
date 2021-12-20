using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Dag20 : Dag
    {
        public Dag20(string s) : base(s)
        {

        }
        public bool[] enhancementkey = new bool[512];
        public bool[,] inputmap;
        public bool[,] outputmap;
        public int startmargin = 10;
        public int dimension;

        public override void Puzzel1()
        {
            string enhancementstring = lines[0];
            dimension = lines[3].Length + (startmargin*2);
            inputmap = new bool[dimension, dimension];
            outputmap = new bool[dimension, dimension];
            for (int i = 0; i < enhancementstring.Length; i++)
            {
                if(enhancementstring[i] == '#')
                    enhancementkey[i] = true;
            }
            InitializeInputmap();
            this.result2 = getSegmentValue(13, 13).ToString();
            Enhance();
            inputmap = outputmap;
            outputmap = new bool[dimension, dimension];
            /*voor debug redenen
            int answer = 0;
            for (int y = 0; y < dimension; y++)
                for (int x = 0; x < dimension; x++)
                    if (inputmap[x, y])
                        answer++;
            //this.result2 = answer.ToString();
            //tot hier*/
            Enhance();
            answer = 0;
            for (int y = 0; y < dimension; y++)
                for (int x = 0; x < dimension; x++)
                    if (outputmap[x, y])
                        answer++;
            this.result1 = answer.ToString();
        }

        public override void Puzzel2()
        {
            //throw new NotImplementedException();
        }

        public void InitializeInputmap()
        {
            for (int y = 2; y < lines.Length; y++)
                for (int x = 0; x < lines[y].Length; x++)
                    if (lines[y][x] == '#')
                        inputmap[x + startmargin,y + startmargin - 2] = true;
        }

        public bool getpixelatcoord(int x, int y)
        {
            if(y < 0 || y >= dimension)
                return false;
            if(x < 0 || x >= dimension)
                return false;
            return inputmap[x,y];
        }

        public void Enhance()
        {
            for(int x = 0; x < dimension; x++)
                for(int y = 0; y < dimension; y++)
                {
                    outputmap[x,y] = enhancementkey[getSegmentValue(x,y)];
                }
        }

        public int getSegmentValue(int x, int y)
        {
            int value = 0;
            if (getpixelatcoord(x - 1, y - 1))
                value += 0b_10000000;
            if (getpixelatcoord(x, y - 1))
                value += 0b_01000000;
            if (getpixelatcoord(x + 1, y - 1))
                value += 0b_001000000;
            if (getpixelatcoord(x - 1, y))
                value += 0b_000100000;
            if (getpixelatcoord(x, y))
                value += 0b_000010000;
            if (getpixelatcoord(x + 1, y))
                value += 0b_000001000;
            if (getpixelatcoord(x - 1, y + 1))
                value += 0b_000000100;
            if (getpixelatcoord(x, y + 1))
                value += 0b_000000010;
            if (getpixelatcoord(x + 1, y + 1))
                value += 0b_000000001;
            return value;
        }
    }
}
