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
        public int startmargin = 105;
        public int dimension;
        public string[] debug = new string[10];
        int iterationcount = 0;

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
            //this.result2 = getSegmentValue(15, 15).ToString();
            Enhance();
            inputmap = outputmap;
            outputmap = new bool[dimension, dimension];
            Enhance();
            string outputstring = "";
            for (int y = 0; y < dimension; y++)
            {
                for (int x = 0; x < dimension; x++)
                {
                    if (outputmap[y, x])
                        outputstring += '#';
                    else
                        outputstring += '?';
                }
                outputstring += '\n';
            }
            debug[3] = outputstring;
            int answer = 0;
            for (int y = 0; y < dimension; y++)
                for (int x = 0; x < dimension; x++)
                    if (outputmap[y, x])
                        answer++;
            this.result1 = answer.ToString();

        }

        public override void Puzzel2()
        {
            inputmap = outputmap;
            outputmap = new bool[dimension, dimension];
            for (int i = 2; i < 50; i++)
            {
                Enhance();
                inputmap = outputmap;
                outputmap = new bool[dimension, dimension];
            }
            int answer = 0;
            for (int y = 0; y < dimension; y++)
                for (int x = 0; x < dimension; x++)
                    if (inputmap[y, x])
                        answer++;
            this.result2 = answer.ToString();
        }

        public void InitializeInputmap()
        {
            for (int y = 2; y < lines.Length; y++)
                for (int x = 0; x < lines[y].Length; x++)
                    if (lines[y][x] == '#')
                        inputmap[y + startmargin - 2,x + startmargin] = true;
        }

        public bool getpixelatcoord(int y, int x)
        {
            if (y < 0 || y >= dimension || x < 0 || x >= dimension)
            {
                if (iterationcount % 2 == 0)
                    return false;
                else
                    return enhancementkey[0];
            }
            return inputmap[y,x];
        }

        public void Enhance()
        {
            for(int x = 0; x < dimension; x++)
                for(int y = 0; y < dimension; y++)
                {
                    outputmap[y,x] = enhancementkey[getSegmentValue(y,x)];
                }
            iterationcount++;
        }

        public int getSegmentValue(int y, int x)
        {
            int value = 0;
            if (getpixelatcoord(y - 1, x - 1))
                value += 0b_100000000;
            if (getpixelatcoord(y - 1, x))
                value += 0b_010000000;
            if (getpixelatcoord(y - 1, x + 1))
                value += 0b_001000000;
            if (getpixelatcoord(y, x - 1))
                value += 0b_000100000;
            if (getpixelatcoord(y, x))
                value += 0b_000010000;
            if (getpixelatcoord(y, x + 1))
                value += 0b_000001000;
            if (getpixelatcoord(y + 1, x - 1))
                value += 0b_000000100;
            if (getpixelatcoord(y + 1, x))
                value += 0b_000000010;
            if (getpixelatcoord(y + 1, x + 1))
                value += 0b_000000001;
            return value;
        }
    }
}
