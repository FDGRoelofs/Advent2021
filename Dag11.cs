using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Dag11 : Dag
    {
        public Dag11(string s, bool b) : base(s, b)
        {
            fieldwidth = lines[0].Length;
            fieldheight = lines.Length;
            squidfield = new int[fieldheight, fieldwidth];
            for (int y = 0; y < fieldheight; y++)
                for (int x = 0; x < fieldwidth; x++)
                {
                    squidfield[y, x] = Int32.Parse("" + lines[y][x]);
                }
            Puzzel1();
            Puzzel2();
        }
        public int[,] squidfield;
        int fieldwidth;
        int fieldheight;
        int totalflashes;
        bool done = false;

        public override void Puzzel1()
        {
            totalflashes = 0;
            for (int i = 0; i < 100; i++)
                if (passtime() == fieldheight * fieldwidth)
                {
                    this.result2 = (i+1).ToString();
                    done = true;
                }   
            this.result1 = totalflashes.ToString();
            // alles + 1
            // check op negens
            // flits
            // recursie naar check op negens
            // zet alle geflitste op 0
        }

        public override void Puzzel2()
        {
            if(!done)
            {
                for(int i = 100; i < 1000; i++)
                    if (passtime() == fieldheight * fieldwidth)
                    {
                        this.result2 = (i+1).ToString();
                        break;
                    }
            }
        }

        public int passtime()
        {
            bool[,] flashed = new bool[fieldheight, fieldwidth];
            for (int y = 0; y < fieldheight; y++)
                for (int x = 0; x < fieldwidth; x++)
                    squidfield[y, x]++;
            int val = checkEnergy(flashed, 0);
            for (int y = 0; y < fieldheight; y++)
                for (int x = 0; x < fieldwidth; x++)
                    if (flashed[y, x])
                        squidfield[y, x] = 0;
            return val;
        }

        public int checkEnergy(bool[,] flashed, int countflashes)
        {
            int currentflashes = 0;
            for (int y = 0; y < fieldheight; y++)
                for (int x = 0; x < fieldwidth; x++)
                {
                    if (!flashed[y, x])
                        if(squidfield[y,x] > 9)
                        {
                            flash(x, y);
                            flashed[y, x] = true;
                            currentflashes++;
                        }
                }
            totalflashes += currentflashes;
            countflashes += currentflashes;
            if (countflashes == fieldwidth * fieldheight)
                return countflashes;

            if (currentflashes > 0)
                return checkEnergy(flashed, countflashes);
            else
                return 0;
        }

        public void flash(int x, int y)
        {
            for(int i = y-1;i < y + 2 ; i++)
                for(int n = x - 1; n < x + 2; n++)
                {
                    bool inbounds = (i >= 0 && i < fieldheight && n >= 0 && n < fieldwidth);
                    if (inbounds)
                        squidfield[i, n]++;
                }
        }
    }
}
