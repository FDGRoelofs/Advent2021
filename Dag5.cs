using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace AdventOfCode2021
{
    class Dag5 : Dag
    {
        public Dag5(string s) : base(s)
        {

        }

        public int[,] field; //hier aanpassen voor test data

        public override void Puzzel1()
        {
            field = new int[1000, 1000];
            for (int i = 0; i < lines.Length; i++)
            {
                var positions = stringToLine(lines[i]);
                placeVents(positions.Item1, positions.Item2, false);
            } 
            this.result1 = countOverlap().ToString();
        }

        public override void Puzzel2()
        {
            field = new int[1000, 1000];
            for (int i = 0; i < lines.Length; i++)
            {
                var positions = stringToLine(lines[i]);
                placeVents(positions.Item1, positions.Item2, true);
            }
            this.result2 = countOverlap().ToString();
        }

        public (Vector2, Vector2) stringToLine(string inp)
        {
            //var output = (0, 0, 0, 0);
            int[] output = new int[4];
            string[] b = inp.Split('>');
            char[] trimChar = new char[] { ' ', '-', '\r' };
            string[] start = b[0].Trim(trimChar).Split(',');
            string[] end = b[1].Trim(trimChar).Split(',');
            Vector2 posA = new Vector2( float.Parse(start[0]), float.Parse(start[1]));
            Vector2 posb = new Vector2(float.Parse(end[0]), float.Parse(end[1]));
            output[0] = Int32.Parse(start[0]);
            output[1] = Int32.Parse(start[1]);
            output[2] = Int32.Parse(end[0]);
            output[3] = Int32.Parse(end[1]);
            return (posA, posb);
        }

        public void placeVents(Vector2 posA, Vector2 posB, bool puzzel2)
        {
            Vector2 line = posB - posA;
            int linelength = getLineLength(line);
            Vector2 direction = florisNormalize(line);//System.Numerics.Vector2.Normalize(line);
            Vector2 current = posA;
            if(puzzel2 | (direction.X == 0 | direction.Y == 0))//|
                for (int i = 0; i <= linelength; i++)
                {
                    field[(int)current.X, (int)current.Y]++;
                    current += direction;
                }
        }

        public int countOverlap()
        {
            int value = 0;
            for (int x = 0; x < field.GetLength(0); x++) 
                for (int y = 0; y < field.GetLength(1); y++)
                    if (field[x, y] > 1)
                        value++;
            return value;
        }

        public int getLineLength(Vector2 line)
        {
            double valA = Math.Sqrt(Math.Pow(line.X, 2));
            double valB = Math.Sqrt(Math.Pow(line.Y, 2));

            return (int)Math.Max(valA, valB);
        }

        public Vector2 florisNormalize(Vector2 input)// de normalize method in csharp heeft raar gedrag, dus doe ik het maar lekker zelf
        {
            Vector2 output = new Vector2(0,0);
            if (input.X > 0)
                output.X = 1;
            if (input.X < 0)
                output.X = -1;
            if (input.Y > 0)
                output.Y = 1;
            if (input.Y < 0)
                output.Y = -1;
            return output;
        }
    }
}
