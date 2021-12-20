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
            int answer = 0;
            for (int y = 0; y < dimension; y++)
                for (int x = 0; x < dimension; x++)
                    if (outputmap[y, x])
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
                        inputmap[y + startmargin,x + startmargin - 2] = true;// hoe moest deze ookalweer? min -2 aan de ene of andere kant geeft zelfde antwoord.
        }

        public bool getpixelatcoord(int y, int x)
        {
            if(y < 0 || y >= dimension)
                return false;
            if(x < 0 || x >= dimension)
                return false;
            return inputmap[y,x];
        }

        public void Enhance()
        {
            for(int x = 0; x < dimension; x++)
                for(int y = 0; y < dimension; y++)
                {
                    outputmap[y,x] = enhancementkey[getSegmentValue(y,x)];
                }
        }

        public int getSegmentValue(int x, int y)
        {
            int value = 0;
            if (getpixelatcoord(y - 1, x - 1))
                value += 0b_10000000;
            if (getpixelatcoord(y - 1, x))
                value += 0b_01000000;
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
            if (getpixelatcoord(y + 1 + 1, x + 1))
                value += 0b_000000001;
            return value;
        }
    }
}
